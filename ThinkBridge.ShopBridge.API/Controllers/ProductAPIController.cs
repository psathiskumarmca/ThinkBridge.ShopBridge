using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.Model;
using ThinkBridge.ShopBridge.Business.UOW;
using ThinkBridge.ShopBridge.Business.Helper;
using System.Net.Http;

namespace ThinkBridge.ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductItems _iProductItems;

        public ProductAPIController(IProductItems iProductItems)
        {
            _iProductItems = iProductItems;
        }

        // GET api/Product
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {
            try
            {
                return Ok(await _iProductItems.GetAllProducts());
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while get all Products: " + ex.Message);
            }
        }

        // GET api/Product/5
        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<ActionResult<ProductModel>> Get(int id)
        {
            try
            {
                ProductModel productModel = await _iProductItems.GetProduct(id);
                if (productModel == null)
                    return NotFound();

                return Ok(productModel);
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error while get Product based on the Id: {id} : {ex.Message}");
            }
        }

        // POST api/Product
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<bool>> Add([FromBody]ProductModel productModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool result = await _iProductItems.Add(productModel);
                if (result)
                    return Ok(true);
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error while add new Product : {ex.Message}");
            }
        }

        // PUT api/Product/5
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<bool>> Update([FromBody] ProductModel productModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                bool result = await _iProductItems.Update(productModel);
                if (result)
                    return Ok(true);
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error while update Product : {ex.Message}");
            }
        }

        // DELETE api/Product/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                ProductModel productModel = await _iProductItems.GetProduct(id);
                if (productModel == null)
                    return NotFound();
                else
                    return Ok(await _iProductItems.Delete(id));
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, ControllerContext.RouteData.Values["controller"].ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error while delete Product id {id} : {ex.Message}");
            }
        }
    }
}
