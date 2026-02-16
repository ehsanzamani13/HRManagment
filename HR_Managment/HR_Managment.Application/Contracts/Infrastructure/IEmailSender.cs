using HR_Managment.Application.Models;

namespace HR_Managment.Application.Contracts.Infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}