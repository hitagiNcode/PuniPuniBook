using Microsoft.Extensions.Configuration;
using PuniPuniBook.Application.IServices;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PuniPuniBook.Application.Services;

public class EmailService : IEmailService
{
    public string SendGridSecret { get; set; }

    public EmailService(IConfiguration config)
    {
        SendGridSecret = config.GetSection("SendGridSecret").Value;
    }
    
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new SendGridClient(SendGridSecret);
        var from = new EmailAddress("info@punipunibook.com", "PuniPuni Book");
        var to = new EmailAddress(email);
        var msg = MailHelper.CreateSingleEmail(from, to, subject,"", htmlMessage);
        return client.SendEmailAsync(msg);
    }
}