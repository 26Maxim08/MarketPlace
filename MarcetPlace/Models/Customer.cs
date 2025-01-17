using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class customer
    {

        public int customerid { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string phone { get; set; }

        [Required]
        [Display(Name = "email")]
        public string email { get; set; }

        [Display(Name = "Полное имя")]
        public string fullname => $"{firstname} {lastname}";
    }
}
