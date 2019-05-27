using System;
using System.Net;

namespace Icebox.Infrastructure
{
    public class HttpProxy
    {
        public readonly string Url;
        public HttpProxy(string url)
        {
            if (!url.StartsWith("http") || url == null)
            {
                throw new Exception("HttpProxy: Bad Url Format");
            }

            Url = url;
        }

        public string GetResponse()
        {
            var client = new WebClient();
            return client.DownloadString(Url);
        }
    }
}
