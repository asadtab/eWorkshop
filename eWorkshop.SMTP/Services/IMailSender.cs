using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.SMTP.Services
{
    public interface IMailSenderService
    {
        Task SendEmail(string message);
    }
}
