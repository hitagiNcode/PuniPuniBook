﻿namespace PuniPuniBook.Application.IServices;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}