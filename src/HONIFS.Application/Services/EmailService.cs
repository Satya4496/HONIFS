
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Emailing;

namespace HONIFS.Services
{
    class EmailService
    {

        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task DoItAsync()
        {
            await _emailSender.SendAsync(
                "satyasaigunnam@gmail.com",     // target email address
                "welcome satya",         // subject
                "This is email body..."  // email body
            );
        }
    }
}
