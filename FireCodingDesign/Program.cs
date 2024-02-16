using FireCodingDesign;
using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) // true
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//IWebHostBuilder CreateWebHostBuilder(string[] args)  // Extra kontakta start.cs not working
//{
//    return (IWebHostBuilder)WebHost.CreateDefaultBuilder(args)
//        .UseStartup<Startup>()
//        .Build();
//}

builder.Services.AddControllersWithViews();

var app = builder.Build();

var startup = new Startup(builder.Configuration);
startup.Configure(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Extra
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
//IHostBuilder CreateHostBuilder(string[] args)
//{
//    return Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseStartup<Startup>();
//            });
//}

//var host = CreateHostBuilder(args).Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        // Hämta SignInManager och UserManager
//        var signInManager = services.GetRequiredService<SignInManager<ApplicationUser>>();
//        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

//        // Logga ut alla användare
//        await signInManager.SignOutAsync();

//        // Skapa superadmin om den inte finns
//        string email = "superadmin@firecoding.se";
//        string password = "p@sSw0rd";

//        var user = new ApplicationUser
//        {
//            UserName = email,
//            Email = email,
//            FirstName = "Super",
//            LastName = "Admin",
//            Mobile = "123456789" // ange ett giltigt mobilnummer
//        };

//        if (await userManager.FindByEmailAsync(email) == null)
//        {
//            await userManager.CreateAsync(user, password);
//            await userManager.AddToRoleAsync(user, "SuperAdmin");
//        }
//    }
//    catch (Exception ex)
//    {
//        // Logga eventuella fel
//        Console.WriteLine(ex.Message);
//    }
//}

//// Fortsätt med att köra webbappen
//await app.RunAsync();


// Adding SuperUser member
using (var scope = app.Services.CreateScope())
{
    //var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();

    //await signInManager.SignOutAsync();

    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "superadmin@firecoding.se";
    string password = "p@sSw0rd";

    var user = new ApplicationUser
    {
        UserName = email,
        Email = email,
        FirstName = "Super",
        LastName = "Admin",
        Mobile = "123456789" // set a valid mobile number
    };

    if (await userManager.FindByEmailAsync(email) == null)
    {
        //        var user = new IdentityUser();
        //        user.UserName = email;
        //        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "SuperAdmin");
    }
}

app.Run();
