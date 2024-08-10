using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.SMTP.Services
{
    public interface IEmailService
    {
        void SendMessage(string message);
    }
}
