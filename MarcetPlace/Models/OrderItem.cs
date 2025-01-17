using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class orderitem
    {
        [Required]
        [Display(Name = "order")]
        public int orderid { get; set; }

        [Required]
        [Display(Name = "product")]
        public int productid { get; set; }

        [Required]
        [Display(Name = "quantity")]
        public int quantity { get; set; }

        public order order { get; set; }
        public product product { get; set; }
    }
}
