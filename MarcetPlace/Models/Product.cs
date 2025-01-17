using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class product
    {
        public int productid { get; set; }

        [Required]
        [Display(Name = "product Name")]
        public string nameproduct { get; set; }

        [Display(Name = "description")]
        public string description { get; set; }

        [Display(Name = "image URL")]
        public string image { get; set; }

        [Required]
        [Display(Name = "price")]
        public decimal price { get; set; }

        [Required]
        [Display(Name = "Stock quantity")]
        public int stockquantity { get; set; }

        public ICollection<orderitem> orderitems { get; set; }
    }
}
