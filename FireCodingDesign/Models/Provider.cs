using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TypeOfProvider { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
