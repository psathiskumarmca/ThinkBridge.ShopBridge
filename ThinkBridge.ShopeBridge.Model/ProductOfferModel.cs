
namespace ThinkBridge.ShopBridge.Model
{
    public class ProductOfferModel
    {
        public int OfferId { get; set; }
        public int? fk_ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
