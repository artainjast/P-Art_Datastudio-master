using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PArt.Pages.P_Art.Repository
{
    public class Class_Core
    {
        public bool SendMailMessage(string from, string to, string bcc, string cc, string subject, string body)
        {
            try
            {
                // Instantiate a new instance of MailMessage
                MailMessage mMailMessage = new MailMessage();

                // Set the sender address of the mail message
                mMailMessage.From = new MailAddress(from);
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(to));

                // Check if the bcc value is null or an empty string\mo
                if ((bcc != null) && (bcc != string.Empty))
                {
                    // Set the Bcc address of the mail message
                    mMailMessage.Bcc.Add(new MailAddress(bcc));
                }      // Check if the cc value is null or an empty value
                if ((cc != null) && (cc != string.Empty))
                {
                    // Set the CC address of the mail message
                    mMailMessage.CC.Add(new MailAddress(cc));
                }       // Set the subject of the mail message
                mMailMessage.Subject = subject;
                // Set the body of the mail message
                mMailMessage.Body = body;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mSmtpClient = new SmtpClient();
                // Send the mail message
                mSmtpClient.Send(mMailMessage);
                return true;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {


                return false;
            }
        }

        public static Image getUrlImage(string psUrl)
        {
            WebResponse result = null;
            Image rImage = null;

            try
            {
                WebRequest request = WebRequest.Create(psUrl);
                byte[] rBytes;
                // Get the content
                result = request.GetResponse();
                Stream rStream = result.GetResponseStream();

                // Bytes from address
                using (BinaryReader br = new BinaryReader(rStream))
                {
                    // Ask for bytes bigger than the actual stream
                    rBytes = br.ReadBytes(1000000);
                    br.Close();
                }
                // close down the web response object
                result.Close();

                // Bytes into image
                using (MemoryStream imageStream = new MemoryStream(rBytes, 0, rBytes.Length))
                {
                    imageStream.Write(rBytes, 0, rBytes.Length);
                    rImage = Image.FromStream(imageStream, true);
                    imageStream.Close();
                }

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            finally
            {
                if (result != null) result.Close();
            }

            return rImage;
        }

    }
}