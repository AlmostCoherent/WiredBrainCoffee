using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.API
{
    public class Destination
    {
        public string Uri { get; set; }
        public bool RequiresAuthentication { get; set; }
        static HttpClient client = new HttpClient();
        public Destination(string uri, bool requiresAuthentication)
        {
            Uri = uri;
            RequiresAuthentication = requiresAuthentication;
        }

        public Destination(string path)
            : this(path, false)
        {
        }

        private Destination()
        {
            Uri = "/";
            RequiresAuthentication = false;
        }

        public async Task<HttpResponseMessage> SendRequest(HttpRequest request)
        {
            string requestContent = GetBodyContent(request);

            using (var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), Uri))
            {
                string contentType = GetContentType(request);
                newRequest.Content = new StringContent(requestContent, Encoding.UTF8, contentType);
                var response = await client.SendAsync(newRequest);
                return response;
            }
        }
        public async Task<HttpResponseMessage> PostRequest(HttpRequest request)
        {
            string requestContent = GetBodyContent(request);
            var content = new StringContent(requestContent, Encoding.UTF8, request.ContentType);
            var response = await client.PostAsync(Uri, content);
            return response;
        }

        private static string GetBodyContent(HttpRequest request)
        {
            string requestContent;
            using (var reader = new StreamReader(request.Body))
            {
                requestContent = reader.ReadToEnd();
            }
            return requestContent;
        }

        private static string GetContentType(HttpRequest httpRequest)
        {
            if (httpRequest.ContentType != null)
            {
                string[] contentTypeSplit = httpRequest.ContentType?.Split(";");
                return contentTypeSplit[0];
            }
            return "text/html";
        }
    }
}
