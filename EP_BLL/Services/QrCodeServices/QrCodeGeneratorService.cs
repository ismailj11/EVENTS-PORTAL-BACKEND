using EP_DAL.Repositories.Invitations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZXing.Common;
using ZXing.Rendering;
using ZXing;

namespace EP_BLL.Services.QrCodeServices
{
    public class QRCodeGeneratorService
    {
        private readonly IInvitationRepository _invitationRepository;

        
        public static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456");
        public static readonly byte[] IV = Encoding.UTF8.GetBytes("6543210987654321");

        public QRCodeGeneratorService(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        public async Task<string> GenerateQRCodeAsync(int invitationId)
        {
            var invitation = await _invitationRepository.GetInvitationWithEventAsync(invitationId);
            if (invitation == null)
            {
                throw new Exception("Invitation not found.");
            }

            var encryptedId = Encrypt(invitation.InvitationId, Key, IV);

            var qrData = new
            {
                InvitationID = encryptedId,

            };

            string qrCodeContent = JsonConvert.SerializeObject(qrData);

            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions { Height = 300, Width = 300, Margin = 0 },
                Renderer = new PixelDataRenderer()
            };

            var pixelData = writer.Write(qrCodeContent);

            using var ms = new MemoryStream();
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height))
            {
                var bitmapData = bitmap.LockBits(
                    new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                bitmap.UnlockBits(bitmapData);

                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Encrypt(int invitationId, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(invitationId);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public string Decrypt(string encryptedId, byte[] key, byte[] iv)
        {
            byte[] cypherText = Convert.FromBase64String(encryptedId);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cypherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
