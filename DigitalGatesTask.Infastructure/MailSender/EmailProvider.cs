using DigitalGatesTask.Infastructure.MailSender.Consts;
using DigitalGatesTask.Shared;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGatesTask.Infastructure.MailSender
{
    public class EmailProvider
    {
        private const string BaseUrl = "https://send.api.mailtrap.io/api";
        private const string ApiToken = "17b7a76129ca95ebf2ad3dd7321201d9";
        private const string FromEmail = "hello@demomailtrap.com";

        public async Task<Result> SendEmailAsync(string to, string title, string content)
        {
            var client = new RestClient($"{BaseUrl}/{UrlConstants.SendEmailUrl}");

            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader(HeaderConstants.ApiTokenKey, ApiToken); // Replace with your actual API token
            request.AddHeader(HeaderConstants.ContentTypeKey, HeaderConstants.JsonContentTypeValue);

            var body = new
            {
                to = new[]
                {
                new { email = to }
            },
                from = new
                {
                    email = FromEmail
                },
                subject = title,
                text = content
            };

            request.AddJsonBody(body);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                return Functional.Failure(response.ErrorMessage);
            }

            return Functional.Success();
        }
    }
}
