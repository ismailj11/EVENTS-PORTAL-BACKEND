using EP_BLL.Dto.MarkAttendance;
using EP_DAL.Repositories.MarkAttendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Services.MarkAttendance
{
    public class MarkAttendanceService : IMarkAttendanceService
    {
        private readonly IMarkAttendancerepository _markAttendanceRepository;

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("6543210987654321");

        public MarkAttendanceService(IMarkAttendancerepository markAttendanceRepository)
        {
            _markAttendanceRepository = markAttendanceRepository;
        }


        public async Task UpdateAttendanceStatusAsync(MarkAttendanceDto markAttendanceDto)

        {
            int invitationId = Decrypt(markAttendanceDto.InvitationId, Key, IV);




            var invitation = await _markAttendanceRepository.GetInvitationByIdAsync(invitationId);
            if (invitation == null)
            {
                throw new Exception("Invitation not found.");
            }


            await _markAttendanceRepository.UpdateAttendancerepStatusAsync(invitationId, (bool)markAttendanceDto.AttendanceStatus, (DateTime)markAttendanceDto.AttendedAt);
            await _markAttendanceRepository.SaveChangesAsync();
        }



        public int Decrypt(string encryptedId, byte[] key, byte[] iv)
        {
            byte[] cipherText = Convert.FromBase64String(encryptedId);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return int.Parse(srDecrypt.ReadToEnd());
                        }
                    }
                }
            }
        }

    }
}
