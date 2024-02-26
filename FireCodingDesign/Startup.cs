using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FireCodingDesign
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("Startup constructor 1 called.");
            Configuration = configuration;
        }

        public Startup()  // Extra för
        {
            Console.WriteLine("Startup default constructor called.");
        }

        public void Configure(IApplicationBuilder app)  // Extra
        {
            Console.WriteLine("Configure method called.");
        }

        public IConfiguration Configuration { get; }

        public class MyShutdownService : IHostedService
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public MyShutdownService(IHttpContextAccessor httpContextAccessor)
            {
                Console.WriteLine("MyChutDownService method called.");
                _httpContextAccessor = httpContextAccessor;
            }

            public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

            public async Task StopAsync(CancellationToken cancellationToken)
            {
                Console.WriteLine("My stopAsync method called.");
                var httpContext = _httpContextAccessor.HttpContext;
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }


        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureServices method called.");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddSignInManager<SignInManager<ApplicationUser>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddHostedService<MyShutdownService>();

        }
    }
}
