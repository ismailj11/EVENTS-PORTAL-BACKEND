using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace EP_BLL.Services.EmailServices
{
    public class EmailSender
    {
        private readonly string _apiKey;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public EmailSender(string apiKey, string senderEmail, string senderName)
        {
            _apiKey = apiKey;
            _senderEmail = senderEmail;
            _senderName = senderName;

            if (Configuration.Default.ApiKey.ContainsKey("api-key"))
            {
                Configuration.Default.ApiKey["api-key"] = _apiKey;
            }
            else
            {
                Configuration.Default.ApiKey.Add("api-key", _apiKey);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiInstance = new TransactionalEmailsApi();

            var email = new SendSmtpEmail(
                to: new List<SendSmtpEmailTo> { new SendSmtpEmailTo(toEmail) },
                subject: subject,
                htmlContent: content,
                sender: new SendSmtpEmailSender(_senderName, _senderEmail)
            );

            try
            {
                await apiInstance.SendTransacEmailAsync(email);
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Exception when sending email: {ex.Message}");
                throw;
            }
        }
    }
}
