using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ThinkBridge.ShopBridge.Model;


namespace ThinkBridge.ShopBridge.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/Product
        public IEnumerable<ThinkBridge.ShopBridge.Model.ProductModel> Get()
        {
            return new ProductItems().GetAllProducts();
        }

        // GET api/Product/5
        public IHttpActionResult Get(int id)
        {
            ProductModel productModel = new ProductItems().GetProduct(id);
            if (productModel == null)
                return NotFound();

            return Ok(productModel);
        }

        // POST api/Product
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult Post(ProductModel productModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool result = new ProductItems().Add(productModel);
                if (result)
                    return StatusCode(HttpStatusCode.NoContent);
                else
                    return StatusCode(HttpStatusCode.ExpectationFailed);
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        // PUT api/Product/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult Put(ProductModel productModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool result = new ProductItems().Update(productModel);
                if (result)
                    return StatusCode(HttpStatusCode.NoContent);
                else
                    return StatusCode(HttpStatusCode.ExpectationFailed);
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        // DELETE api/Product/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ProductModel productModel = new ProductItems().GetProduct(id);
                if (productModel == null)
                    return NotFound();
                else
                    new ProductItems().Delete(id);
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }

            return Ok();
        }
    }
}

