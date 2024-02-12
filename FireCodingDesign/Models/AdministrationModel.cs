using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class AdministrationModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        [Display(Name = "Username (E-Mail)")]
        public string? UserName { get; set; }
        [Display(Name = "Full name")]
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }
        public List<Department> Departments { get; set; }
    }
}
