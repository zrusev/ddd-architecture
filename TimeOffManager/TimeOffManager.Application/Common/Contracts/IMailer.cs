namespace TimeOffManager.Application.Common.Contracts
{
    using Entities;
    using System.Threading.Tasks;

    public interface IMailer
    {
        Task SendEmailAsync(MailOutputModel mail);
    }
}