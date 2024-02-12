using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Identity;

namespace FireCodingDesign.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FireCodingDesign.Models.Company> Company { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Provider> Provider { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Customer> Customer { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Order> Order { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Department> Department { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Adding colums to AppNetUsers
            builder.Entity<ApplicationUser>()
                   .Property(u => u.FirstName)
                   .HasMaxLength(100);

            builder.Entity<ApplicationUser>()
                   .Property(u => u.LastName)
                   .HasMaxLength(100);

            builder.Entity<ApplicationUser>()
                   .Property(u => u.Mobile)
                   .HasMaxLength(100);

            // Adding Roles to AspNetRoles
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "PowerUser",
                NormalizedName = "POWERUSER"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Owner",
                NormalizedName = "OWNER"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            });
            
            // Adding Companies
            builder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                CompanyName = "Firecoding Design",
                Description = "Best coding company there are!",
                PhoneNumber = "0011-000001",
                Email = "Home@firecoding.se",
                Adress = "Hemma vid rondellen",
                OrganizationNumber = "000000-0001"
            });

            builder.Entity<Company>().HasData(new Company
            {
                CompanyId = 2,
                CompanyName = "Firecoding Backend",
                Description = "Best Backend coding company there are!",
                PhoneNumber = "0011-000002",
                Email = "backend@firecoding.se",
                Adress = "Hemma vid andra rondellen",
                OrganizationNumber = "000000-0002"
            });

            builder.Entity<Company>().HasData(new Company
            {
                CompanyId = 3,
                CompanyName = "Firecoding Frontend",
                Description = "Best Frontend coding company there are!",
                PhoneNumber = "0011-000003",
                Email = "frontend@firecoding.se",
                Adress = "Hemma vid en annan rondell",
                OrganizationNumber = "000000-0003"
            });

            // Adding Departments
            builder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                DepartmentName = "Firecoding Frontend",
                DepartmentDescription = "Frontend coding"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                DepartmentName = "Firecoding SQL Design",
                DepartmentDescription = "SQL design"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 3,
                DepartmentName = "Firecoding BackEnd",
                DepartmentDescription = "Backend coding"
            });

            builder.Entity<Department>().HasData(new Department
            {   
                Id = 4,
                DepartmentName = "Firecoding Testing",
                DepartmentDescription = "Application testing"
            });
        }

        internal Company? FindAsync(int? companyId1, int companyId2)
        {
            throw new NotImplementedException();
        }

        public DbSet<FireCodingDesign.Models.AdministrationModel> AdministrationModel { get; set; } = default!;
    }
}
