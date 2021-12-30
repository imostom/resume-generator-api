using App.Core.Models;
using PostmarkDotNet;
using PostmarkDotNet.Legacy;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class PostmarkService 
    {
        private readonly AppConfigurations appConfigurations;
        public PostmarkService(AppConfigurations appConfigurations)
        {
            this.appConfigurations = appConfigurations;
        }

        public async Task<bool> SendEmail() //EmailRequest emailRequest)
        {
            var response = false;
            try
            {
                //var emailTemplate = EmailDbContext.GetEmailTemplate(emailRequest);
                //                emailTemplate.Body = emailTemplate.Body.Replace("{firstname}", emailRequest.Firstname);
                var message = new PostmarkMessage()
                {
                    From = "info@tomiwo.com", //emailTemplate.SenderEmail,
                    To = "imostom@gmail.com", //emailRequest.RecipientEmail,
                    HtmlBody = "test email", //emailTemplate.Body,
                    MessageStream = "outbound",
                    //TextBody = $"Hello {firstname}",  //not in use
                    TrackOpens = true,
                    Subject = "Your Resume", //emailTemplate.Subject,
                    //Headers = headerCollection,
                    Tag = "inbox"
                };


                var client = new PostmarkClient(appConfigurations.PostmarkToken, appConfigurations.PostmarkUrl);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var sendResult = await client.SendMessageAsync(message);

                if (sendResult != null)
                {
                    if (sendResult.Status == PostmarkStatus.Success)
                    {
                        response = true;
                    }
                    else
                    {
                        response = false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;
        }
    }
}
