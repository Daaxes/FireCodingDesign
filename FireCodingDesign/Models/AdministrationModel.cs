using FireCodingDesign.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class AdministrationModel
    {
        [Key]
        public int Id { get; set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }

        [Display(Name = "Username (E-Mail)")]
        public string? UserName { get; set; }
        [Display(Name = "Full name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Departments { get; set; }
        public int? RoleId { get; set; }
        public string? Role { get; set; }
		public List<IdentityRole>? Roles { get; set; }
    }

}
