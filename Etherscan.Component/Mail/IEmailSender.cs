using System.Threading.Tasks;

namespace Etherscan.Component.Mail
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

    }
}
