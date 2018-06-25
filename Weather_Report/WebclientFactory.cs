using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Report
{
    public class WebClientFactory
    {
        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:65427")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
