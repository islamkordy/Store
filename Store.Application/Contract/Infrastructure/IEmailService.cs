using Store.Application.Models;

namespace Store.Application.Contract.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}
