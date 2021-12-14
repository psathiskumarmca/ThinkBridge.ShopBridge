using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ThinkBridge.ShopBridge.Admin.UI.Helper
{
    public class WebClient : IWebClient
    {
        private HttpClient webApicClient;
        private string apiURI;

        public WebClient(IConfiguration iConfig)
        {
            apiURI = iConfig.GetValue<string>("AppSettings:WebAPIURI");

            webApicClient = new HttpClient();
            //Passing service base url
            webApicClient.BaseAddress = new Uri(apiURI);
            webApicClient.DefaultRequestHeaders.Clear();
            //Define request data format  
            webApicClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient GetHttpClietn()
        {
            return webApicClient;
        }
    }
}
