using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.Model;

namespace ThinkBridge.ShopBridge.Business.UOW
{
   public interface IProductItems
    {
        Task<List<ProductModel>> GetAllProducts();

        Task<ProductModel> GetProduct(int productId);

        Task<bool> Add(ProductModel productModel);

        Task<bool> Update(ProductModel productModel);

        Task<bool> Delete(int productId);

        Task<List<ProductOfferModel>> GetAllProductOffers();
    }
}
