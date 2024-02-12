using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCompany { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
