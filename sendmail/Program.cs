using SendGrid.Helpers.Mail;
using System;
using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using System.Threading.Tasks;


namespace sendmail
{
    class Program
    {
        static async Task Main()
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("mail@microsoft.com", "DX Team"),
                Subject = "Knowledge Share",
                PlainTextContent = "Content from word file",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            msg.AddTo(new EmailAddress("mail@microsoft.com", "Test User"));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
