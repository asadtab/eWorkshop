﻿namespace eWorkshop.SMTP.Model
{
    public class EmailModel
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
