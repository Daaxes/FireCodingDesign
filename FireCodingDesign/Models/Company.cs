using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "ID Number")]
        public int CompanyId { get; set; }
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Phonenumber")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Address")]
        public string Adress { get; set; }
        public string OrganizationNumber { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<Provider>? Providers { get; set; }
    }
}
