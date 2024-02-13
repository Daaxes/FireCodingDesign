using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Customers Name")]
        public string? CustomerName { get; set; }
        [Display(Name = "Customers Company")]
        public string? CustomerCompany { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
