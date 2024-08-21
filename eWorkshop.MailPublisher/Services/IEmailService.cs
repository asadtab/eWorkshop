using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.MailPublisher.Services
{
    public interface IEmailService
    {
        Task SendMessage(string message, List<string> sendTo);
    }
}
