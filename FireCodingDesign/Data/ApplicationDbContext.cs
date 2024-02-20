using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Identity;

namespace FireCodingDesign.Data
{
    public class ApplicationDbContext : IdentityDbContext <IdentityUser>
    {
        internal object administrationmodel;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<FireCodingDesign.Models.Company> Company { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Provider> Provider { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Customer> Customer { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Order> Order { get; set; } = default!;
        public DbSet<FireCodingDesign.Models.Department> Department { get; set; } = default!;
		public DbSet<FireCodingDesign.Models.AdministrationModel> AdministrationModel { get; set; } = default!;
        public DbSet<IdentityRole> Role { get; set; }
//        public DbSet<ApplicationUser> User { get; set; }

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

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "None",
                NormalizedName = "NONE"
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
                DepartmentName = "Firecoding Planing",
                DepartmentDescription = "Planning phase"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                DepartmentName = "Firecoding BackEnd",
                DepartmentDescription = "Backend coding phase"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 3,
                DepartmentName = "Firecoding SQL Design",
                DepartmentDescription = "SQL design phase"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 4,
                DepartmentName = "Firecoding Identity coding",
                DepartmentDescription = "Identity coding phase"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 5,
                DepartmentName = "Firecoding Frontend",
                DepartmentDescription = "Frontend coding phase"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 6,
                DepartmentName = "Firecoding Testing",
                DepartmentDescription = "Application testing phase"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 7,
                DepartmentName = "Order sent",
                DepartmentDescription = "Order sent"
            });

            builder.Entity<Department>().HasData(new Department
            {
                Id = 8,
                DepartmentName = "order received and approved",
                DepartmentDescription = "order received and approved"
            });
        }


        internal Company? FindAsync(int? companyId1, int companyId2)
        {
            throw new NotImplementedException();
        }
    }
}
