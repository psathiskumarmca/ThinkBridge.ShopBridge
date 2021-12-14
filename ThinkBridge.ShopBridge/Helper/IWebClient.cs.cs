using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThinkBridge.ShopBridge.Admin.UI.Helper
{
    public interface IWebClient
    { 
        HttpClient GetHttpClietn();
    }
}
