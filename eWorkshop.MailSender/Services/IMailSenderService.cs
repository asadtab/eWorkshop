namespace eWorkshop.MailSender.Services
{
    public interface IMailSenderService
    {
        Task SendEmail(string message);
        void Connect();
    }
}
