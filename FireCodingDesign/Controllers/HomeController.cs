using FireCodingDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using FireCodingDesign.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace FireCodingDesign.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        //public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        //{
        //}

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var existingUser = _context.AdministrationModel.FirstOrDefault(u => u.UserId == userId);

            if (existingUser != null)
            {
                // Kontrollera och uppdatera DepartmentId
                if (existingUser.DepartmentId == null)
                {
                    existingUser.DepartmentId = 100;
                }

                // Kontrollera och uppdatera DepartmentName
                if (string.IsNullOrEmpty(existingUser.DepartmentName) && existingUser.DepartmentId != null)
                {
                    var departmentName = _context.Department
                        .Where(d => d.Id == existingUser.DepartmentId)
                        .Select(d => d.DepartmentName)
                        .FirstOrDefault();

                    existingUser.DepartmentName = departmentName;
                }

                // Uppdatera användaren
                _context.Update(existingUser);
                _context.SaveChanges();
            }

            return View();
        }

        //var models = _context.AdministrationModel.ToList();
        //var model = models.Select(models => new AdministrationModel
        //{
        //    UserId = models.UserId,
        //    UserName = models.UserName,
        //    Email = models.Email,
        //    FirstName = models.FirstName,
        //    LastName = models.LastName,
        //    Mobile = models.Mobile,
        //    DepartmentId = models.DepartmentId,
        //    DepartmentName = _context.Department.Find(models.DepartmentId).DepartmentName,
        //    Departments = _context.Department.ToList(),
        //    Roles = _roleManager.Roles.ToList(),
        //    Role = _context.UserRoles
        //            .Where(ur => ur.UserId == models.UserId)
        //            .Join(_roleManager.Roles, rm => rm.RoleId, ur => ur.Id, (ur, r) => r.Name)
        //            .FirstOrDefault(),
        //}).ToList();

        //            foreach (var user in model.IdentityUserAndRoleList)
        //            {
        //                var userDetails = _context.AdministrationModel
        //                    .FirstOrDefault(u => u.UserId == user.UserId);

        //                if (userDetails != null)
        //                {
        //                    user.DepartmentId = userDetails.DepartmentId;
        //                    user.DepartmentName = _context.Department
        //                                    .FirstOrDefault(d => d.Id == user.DepartmentId)?.DepartmentName;
        ////                    user.DepartmentName = _context.Department.Select(d => d.Id == userDetails.Id).DepartmentName;
        //                    if (user.DepartmentId == null || user.DepartmentId == 0)
        //                    {
        //                        user.DepartmentId = 100;
        //                    }
        //                }
        //            }
        //            AdministrationModel adminmodel = model.IdentityUserAndRoleList
        //            AdminSave(model)
        //AdminSave();
        //    return View();
        //}

        //private void SaveChangesAsync(List<AdministrationModel> identityUserAndRoleList)
        //{
        //    throw new NotImplementedException();
        //}

        //       public async Task AdminSave()
        //       {
        //           var models = _context.AdministrationModel.ToList();
        //           var model = models.Select(models => new AdministrationModel
        //           {
        //               UserId = models.UserId,
        //               UserName = models.UserName,
        //               Email = models.Email,
        //               FirstName = models.FirstName,
        //               LastName = models.LastName,
        //               Mobile = models.Mobile,
        //               DepartmentId = models.DepartmentId,
        //               DepartmentName = _context.Department.Find(models.DepartmentId).DepartmentName,
        //               Departments = _context.Department.ToList(),
        //               Roles = _roleManager.Roles.ToList(),
        //               Role = _context.UserRoles
        //                       .Where(ur => ur.UserId == models.UserId)
        //                       .Join(_roleManager.Roles, rm => rm.RoleId, ur => ur.Id, (ur, r) => r.Name)
        //                       .FirstOrDefault(),
        //           }).ToList();

        //           using (var transaction = await _context.Database.BeginTransactionAsync())
        //           {
        //               try
        //               {
        //                   foreach (var item in models)
        //                   {
        ////                       if (model.UserId == _context.Find(model.UserId)
        //                       _context.Update(item);
        //                       await _context.SaveChangesAsync();
        //                   }

        //                   await transaction.CommitAsync();
        //               }
        //               catch (Exception)
        //               {
        //                   // Ångra transaktionen om det uppstår ett fel
        //                   await transaction.RollbackAsync();
        //                   throw;
        //               }
        //           }
        //       }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //    public class CustomActionFilterAttribute : ActionFilterAttribute
        //    {
        //        private readonly ApplicationDbContext _context;

        //        public CustomActionFilterAttribute(ApplicationDbContext context)
        //        {
        //            _context = context;
        //        }

        //        public override void OnActionExecuting(ActionExecutingContext context)
        //        {
        //            // Kolla om användaren är inloggad
        //            if (context.HttpContext.User.Identity.IsAuthenticated)
        //            {
        //                var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //                // Kolla om användaren har ett AdministrationModel
        //                var adminModel = _context.AdministrationModel.FirstOrDefault(a => a.UserId == userId);

        //                if (adminModel == null)
        //                {
        //                    // Om användaren inte har ett AdministrationModel, lägg till det med standardvärden
        //                    _context.AdministrationModel.Add(new AdministrationModel
        //                    {
        //                        UserId = userId,
        //                        DepartmentId = 100, // Default DepartmentId
        //                        // Lägg till andra fält om det behövs
        //                    });

        //                    _context.SaveChanges();
        //                }

        //                // Kolla om användaren har en roll
        //                var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        //                var user = userManager.FindByIdAsync(userId).Result;
        //                var roles = userManager.GetRolesAsync(user).Result;

        //                if (roles == null || !roles.Any())
        //                {
        //                    // Om användaren inte har några roller, tilldela den rollen "None"
        //                    userManager.AddToRoleAsync(user, "None").Wait();
        //                }
        //            }

        //            base.OnActionExecuting(context);
        //        }

        //    }    
        //
    }
}
