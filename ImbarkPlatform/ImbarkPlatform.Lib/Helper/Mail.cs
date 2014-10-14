using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ImbarkPlatform.Lib.Helper
{
    public class Mail
    {
        private string mailHost;

        private string subject;
        private string body;
        private string to;
        private string cc;
        private string from;

        private string user;
        private string password;
        //format like "file1;file2;file3"
        private string attachmentFiles;

        private SmtpClient smtpClient;
        private MailAddress mailFrom;
        private MailMessage message;

        public Mail( string user, string password, string from, string to, string cc, string subject, string body, string host, string attachmentFiles)
        {
            this.user = user;
            this.password = password;

            this.mailHost = host;

            this.from = from;
            this.to = to;
            this.cc = cc;
            this.subject = subject;
            this.body = body;

            this.attachmentFiles = attachmentFiles;
        }

        public void SendEmail()
        {
            try
            {
                Initialize();
                smtpClient.Send(message);
            }
            finally
            {
                message.Dispose();
                //smtpClient.Dispose();
            }
        }

        public void SendEmailAsync()
        {
            try
            {
                Initialize();
                smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
                smtpClient.SendAsync(message, "");
            }
            catch
            {
                smtpClient.SendAsyncCancel();
                if ( message != null )
                    message.Dispose();
                //if ( smtpClient != null )
                    //smtpClient.Dispose();
            }
        }

        void smtpClient_SendCompleted( object sender, System.ComponentModel.AsyncCompletedEventArgs e )
        {
            Exception error = e.Error;
            if ( error != null )
            {
                // log error message
            }
            if ( message != null )
                message.Dispose();
            //if ( smtpClient != null )
                //smtpClient.Dispose();
        }

        private void Initialize()
        {
            mailFrom = new MailAddress(this.from);
            message = new MailMessage();
            message.Subject = this.subject;
            message.From = this.mailFrom;
            string[] toNames = to.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach ( var name in toNames )
            {
                message.To.Add(new MailAddress(name));
            }

            toNames = cc.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach ( var name in toNames )
            {
                message.CC.Add(new MailAddress(name));
            }

            message.Body = this.body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            if (!string.IsNullOrEmpty(attachmentFiles))
            {
                string[] filenames = attachmentFiles.Split(';');
                foreach ( var filename in filenames )
                {
                    Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
                    message.Attachments.Add(data);
                }
            }
            smtpClient = new SmtpClient();
            //smtpClient.Host = "smtp." + message.From.Host; 
            smtpClient.Host = this.mailHost;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(this.user, this.password);

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            
        }
    }
}
