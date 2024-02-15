using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FireCodingDesign
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void Configure(IApplicationBuilder app)
		{
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		}

		public IConfiguration Configuration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});
			//			services.AddIdentity<IdentityUser, IdentityRole>();
			services.AddIdentity<ApplicationUser, IdentityRole>();

            services.AddControllersWithViews(); // Exempel: Lägg till MVC-tjänster
		}
	}
}
