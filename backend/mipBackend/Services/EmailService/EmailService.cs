using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using mipBackend.Dtos.EmailDtos;
using System.Xml;
using MimeKit.Utils;

namespace mipBackend.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
            /*
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            */
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config.GetSection("SmtpServer").Value, Convert.ToInt32(_config.GetSection("Port").Value), false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_config.GetSection("UsernameMail").Value, _config.GetSection("PasswordMail").Value);

                    client.Send(mailMessage);
                }
                catch 
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _config.GetSection("From").Value));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder();


            
            var image = bodyBuilder.LinkedResources.Add(@"images\BA-mailing-mipnet-top.jpg");
            image.ContentId = MimeUtils.GenerateMessageId();

            var imageFooter = bodyBuilder.LinkedResources.Add(@"images\BA-mailing-mipnet-footer.jpg");
            imageFooter.ContentId = MimeUtils.GenerateMessageId();


            bodyBuilder.HtmlBody = string.Format("<div bgcolor=\"#ffffff\" marginwidth=\"0\" marginheight=\"0\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#ffffff\" align=\"center\"><tbody><tr><td valign=\"top\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"610\" align=\"left\"><tbody><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"20\" height=\"1\"></td><td width=\"570\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"><tbody><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"20\"></td></tr><tr><td bgcolor=\"##77b809\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"18\"></td></tr><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"0\"></td></tr><tr><td><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"><tbody><tr><td bgcolor=\"#ffffff\" valign=\"top\" width=\"570\" style=\"line-height:0;font-size:0px\"><a href=\"https://www.mipnet.cl\"><img alt=\"MIPNET\" src=\"{0}\" width=\"570\" height=\"71\" border=\"0\" /></a></td></tr></tbody></table></td></tr><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"0\"></td></tr><tr><td bgcolor=\"#968877\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"11\"></td></tr><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"27\"></td></tr><tr><td><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"><tbody><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"20\" height=\"1\"></td><td width=\"530\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"><tbody><tr><td bgcolor=\"#ffffff\" style=\"line-height:18px\"><p><font color=\"#333333\" size=\"1\" face=\"Arial, Helvetica, sans-serif\" style=\"line-height:18px;font-size:14px\">{1}<p><font color=\"#333333\" size=\"1\" face=\"Arial, Helvetica, sans-serif\" style=\"line-height:18px;font-size:14px\"></font></p><br></p><br><p><font color=\"#333333\" size=\"1\" face=\"Arial, Helvetica, sans-serif\" style=\"line-height:18px;font-size:14px\"><br>Solicite más información en contacto@mipnet.cl.</font></p><p><font color=\"#333333\" size=\"1\" face=\"Arial, Helvetica, sans-serif\" style=\"line-height:18px;font-size:14px\"><strong>Atentamente</strong></font></p><p><font color=\"#333333\" size=\"1\" face=\"Arial, Helvetica, sans-serif\" style=\"line-height:18px;font-size:14px\"><strong>Equipo MIPnet.</strong></font></p><p> </p></td></tr></tbody></table></td><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"20\" height=\"1\"></td></tr></tbody></table></td></tr><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"28\"></td></tr><tr><td bgcolor=\"#77b809\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"10\"></td></tr><tr><td bgcolor=\"#ffffff\" valign=\"top\" width=\"570\" style=\"line-height:0;font-size:0px\"><a href=\"https://www.mipnet.cl\" target=\"_blank\"><img border=\"0\" alt=\"MIPnet syngenta\"  src=\"{2}\" width=\"570\" height=\"51\" /></a></td></tr><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"10\"></td></tr><tr><td bgcolor=\"#eeede9\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"><tbody><tr><td bgcolor=\"#eeede9\" colspan=\"3\" style=\"line-height:0;font-size:0px\" width=\"1\" height=\"16\"></td></tr><tr><td bgcolor=\"#eeede9\" style=\"line-height:0;font-size:0px\" width=\"20\" height=\"1\"></td><td width=\"530\"></td><td bgcolor=\"#eeede9\" style=\"line-height:0;font-size:0px\" width=\"20\" height=\"1\"></td></tr><tr><td bgcolor=\"#eeede9\" colspan=\"3\" style=\"line-height:0;font-size:0px\" height=\"20\"></td></tr></tbody></table></td></tr><tr><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\"><img hspace=\"0\" alt=\"\" width=\"1\" height=\"20\" src=\"/ba/FCKAttachmentServlet?CLMIntegration=TEMPLATES/8/de/blank.gif\"></td></tr></tbody></table></td><td bgcolor=\"#ffffff\" style=\"line-height:0;font-size:0px\" width=\"20\" height=\"1\"></td></tr></tbody></table></td></tr></tbody></table></div></div><br>", image.ContentId, message.Content.ToString(), imageFooter.ContentId);



            if (message.Attachments != null && message.Attachments.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_config.GetSection("SmtpServer").Value, Convert.ToInt32(_config.GetSection("Port").Value), false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_config.GetSection("UsernameMail").Value, _config.GetSection("PasswordMail").Value);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
        
        private void Confirmacion_Email_Usuario(String stx_EmailDestino, String stx_Asunto, String stx_Contenido_html, String Stx_Contenido_Text)
        {

            

        }

    }


    
}
