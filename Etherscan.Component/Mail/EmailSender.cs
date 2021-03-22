using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Etherscan.Component.Mail
{

    public class EmailSender : IEmailSender
    {
        private readonly string _sendGridKey;
        public EmailSender()
        {
            _sendGridKey = "[SendGridKey]"; //Update here
        }


        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(_sendGridKey, subject, message, email);
        }

        private static Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("mail@domain.com", subject),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
