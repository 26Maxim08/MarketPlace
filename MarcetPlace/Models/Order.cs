using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class order
    {
        public int orderid { get; set; }

        [Required]
        [Display(Name = "customer")]
        public int customerid { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string paymentmethod { get; set; }

        [Required]
        [Display(Name = "Delivery Address")]
        public string deliveryaddress { get; set; }

        public customer customer { get; set; }
        public ICollection<orderitem> orderitems { get; set; }
    }
}
