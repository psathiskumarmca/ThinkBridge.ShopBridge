using ThinkBridge.ShopBridge.Business.Repository;
using ThinkBridge.ShopBridge.DataAccess.Model;

namespace ThinkBridge.ShopBridge.Business.UOW
{
    public interface IUOWProduct
    {
        IRepository<Product> Product { get; }
        IRepository<ProductOffer> ProductOffer { get; }
        bool Commit();
    }
}
