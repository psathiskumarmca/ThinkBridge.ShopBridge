using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.Business.Helper;
using ThinkBridge.ShopBridge.DataAccess.Model;
using ThinkBridge.ShopBridge.Model;

namespace ThinkBridge.ShopBridge.Business.UOW
{
    public class ProductItems : IProductItems
    {
        private readonly IUOWProduct uow;

        public ProductItems(IUOWProduct uOWProduct)
        {
            // It will create DB context
            uow = uOWProduct;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            List<ProductModel> productModels = null;
            try
            {
                var productData = await uow.Product.GetAll();
                productModels = (from item in productData
                                 select new ProductModel
                                 {
                                     ProductId = item.Id,
                                     Name = item.Name,
                                     Description = item.Description,
                                     Price = item.Price
                                 }).ToList();

                return productModels;
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            var productData = await uow.Product.GetById(productId);
            try
            {
                ProductModel productModels = new ProductModel()
                {
                    ProductId = productData.Id,
                    Name = productData.Name,
                    Description = productData.Description,
                    Price = productData.Price
                };
                return productModels;
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        public async Task<bool> Add(ProductModel productModel)
        {
            Product productData = new Product()
            {
                Id = productModel.ProductId,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price
            };

            uow.Product.Add(productData);
            return uow.Commit();
        }

        public async Task<bool> Update(ProductModel productModel)
        {
            try
            {
                Product productData = new Product()
                {
                    Id = productModel.ProductId,
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Price = productModel.Price
                };

                uow.Product.Update(productData);
                return uow.Commit();
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        public async Task<bool> Delete(int productId)
        {
            try
            {
                uow.Product.Delete(productId);
                return uow.Commit();
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        public async Task<List<ProductOfferModel>> GetAllProductOffers()
        {
            List<ProductOfferModel> productOfferModel = null;

            var productOfferData = await uow.ProductOffer.GetAll();

            productOfferModel = (from item in productOfferData
                                 select new ProductOfferModel
                                 {
                                     OfferId = item.Id,
                                     Name = item.Name,
                                     Description = item.Description,
                                     fk_ProductId = item.fk_ProductId,
                                     IsActive = item.IsActive,
                                     IsDelete = item.IsDelete
                                 }).ToList();

            return productOfferModel;
        }

    }
}
