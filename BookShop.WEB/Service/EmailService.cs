using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace BookShop.WEB.Service
{
    public class EmailService
    {
        public async Task SendEmailAsync (string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта BookShop.by", "vita.bu@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message};

            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync("smtp.mail.ru",465,true);
                await smtpClient.AuthenticateAsync("vita.bu@mail.ru", "RVsbpMTEQTvvq6tybnHv");
                await smtpClient.SendAsync(emailMessage);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
