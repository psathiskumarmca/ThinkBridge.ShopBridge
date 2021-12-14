using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.Admin.UI.Helper;
using ThinkBridge.ShopBridge.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ThinkBridge.ShopBridge.Admin.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebClient iWebClient;

        public ProductController(IWebClient iwebClient)
        {
            iWebClient = iwebClient;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductModel> productList = null;

            HttpResponseMessage responseMessage = iWebClient.GetHttpClietn().GetAsync("GetAll").Result;

            //Checking the response is successful or not which is sent using HttpClient  
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                productList = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(responseBody);
            }

            return View(productList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            ProductModel product = new ProductModel();

            if (id != 0)
            {
                HttpResponseMessage responseMessage = iWebClient.GetHttpClietn().GetAsync("GetProduct/" + id.ToString()).Result;

                //Checking the response is successful or not which is sent using HttpClient  
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var productItems = responseMessage.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Product list  
                    product = JsonConvert.DeserializeObject<ProductModel>(productItems);
                }
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult AddorEdit(ProductModel product)
        {
            var productModel = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");
            if (product.ProductId == 0)
            {
                 
                HttpResponseMessage responseMessage = iWebClient.GetHttpClietn().PostAsync("Add", productModel).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMsg"] = "Saved successfull";
                }
                else
                {
                    TempData["SuccessMsg"] = "Error occured while add new product";
                }
            }
            else
            {
                HttpResponseMessage responseMessage = iWebClient.GetHttpClietn().PostAsync("Update", productModel).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMsg"] = "Updated successfull";
                }
                else
                {
                    TempData["SuccessMsg"] = "Error occured while update the product";
                }
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id = 0)
        {
            HttpResponseMessage responseMessage = iWebClient.GetHttpClietn().GetAsync("Delete/" + id.ToString()).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMsg"] = "Deleted successfull";
            }
            else
            {
                TempData["SuccessMsg"] = "Error occured while delete the product";
            }
            return RedirectToAction("index");
        }
    }
}
