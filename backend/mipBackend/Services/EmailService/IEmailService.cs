using mipBackend.Dtos.EmailDtos;

namespace mipBackend.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(Message message);

        Task SendEmailAsync(Message message);
    }
}
