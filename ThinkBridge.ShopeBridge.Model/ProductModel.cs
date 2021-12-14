using System.ComponentModel.DataAnnotations;

namespace ThinkBridge.ShopBridge.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price field is required")]
        public int Price { get; set; }
    }
}
