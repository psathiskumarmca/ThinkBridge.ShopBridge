using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkBridge.ShopBridge.DataAccess.Model
{
    public class ProductOffer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "fk_ProductId field is required")]
        public int? fk_ProductId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }
    }
}
