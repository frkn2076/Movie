using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Movie.Business.Notifier
{
    public static class MailSender
    {
        public static void SendMail(string to, string movieName, string rating, string poster, string htmlDescription)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse("FindYourSoulMatee@gmail.com");
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "Most Rated Movie";

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Resources","Template.html");
            var tempBody = File.ReadAllText(path);
            tempBody = tempBody.Replace("NAME", movieName);
            tempBody = tempBody.Replace("RATING", rating);
            tempBody = tempBody.Replace("IMAGE", poster);
            var body = tempBody.Replace("HTMLDescription", htmlDescription);

            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("FindYourSoulMatee@gmail.com", "fbr01994");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
