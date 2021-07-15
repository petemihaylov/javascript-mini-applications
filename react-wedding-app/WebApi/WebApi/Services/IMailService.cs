using System;
using System.Collections.Generic;
using WebApi.Models;
using WebApi.Dtos;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string toEmail, string subject, string content);

        bool IsValidEmail(string email);
    }
}