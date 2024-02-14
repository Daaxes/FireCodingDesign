using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Identity;

namespace FireCodingDesign.Controllers
{
    public class AdministrationModelsController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;

		public AdministrationModelsController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
		}
		//public AdministrationModelsController(ApplicationDbContext context)
		//      {
		//          _context = context;
		//      }

		// GET: AdministrationModels

		public async Task<ShareDataModel> SyncSharedDataIdentityAsync()
		{
//			int idCounter = 1;
			    ShareDataModel model = new ShareDataModel
			    {
				IdentityUserAndRoleList = (_roleManager.Roles == null || _userManager.Users == null) ? new List<AdministrationModel>() : _userManager.Users
					.Select(u => new AdministrationModel
					{
						UserId = u.Id,
						UserName = u.UserName,
                        Roles = _roleManager.Roles.ToList(),
						Role = _context.UserRoles
							.Where(ur => ur.UserId == u.Id)
							.Join(_roleManager.Roles, rm => rm.RoleId, ur => ur.Id, (ur, r) => r.Name)
							.FirstOrDefault(),
					}).ToList(),
			    };
                
            //using (var context = new ApplicationDbContext())
            //{
                await SaveIdentityUserAndRole(model.IdentityUserAndRoleList, _context);
//            }


            return model;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		private async Task<IActionResult> SaveIdentityUserAndRole(List <AdministrationModel> administrationModel, ApplicationDbContext context)
		{
            if (ModelState.IsValid)
            {
                    foreach (var userWithRoles in administrationModel)
                    {
                        var existingUser = await context.AdministrationModel
                                                              .FirstOrDefaultAsync(u => u.UserId == userWithRoles.UserId);
                        if (existingUser != null)
                        {
                            existingUser.FirstName = userWithRoles.FirstName;
                            existingUser.LastName = userWithRoles.LastName;
                            existingUser.Email = userWithRoles.Email;
                            existingUser.Roles = userWithRoles.Roles;
                            existingUser.RoleId = userWithRoles.RoleId;
                            existingUser.Mobile = userWithRoles.Mobile;
                            existingUser.Departments = userWithRoles.Departments;
                            existingUser.DepartmentId = userWithRoles.DepartmentId;
                        }
                        else
                        {
                            context.AdministrationModel.Add(userWithRoles);
                        }

                    }
                }
			        await context.SaveChangesAsync();
				//         _context.Add(administrationModel.FirstOrDefault());
				//await _context.SaveChangesAsync();
	 	return RedirectToAction(nameof(Index));
		}
        //  	return View(administrationModel);

        public ShareDataModel GetSharedDataIdentity()
        {
            ShareDataModel model = new ShareDataModel
            {
                IdentityUserAndRoleList = (_roleManager.Roles == null || _userManager.Users == null) ? new List<AdministrationModel>() : _context.AdministrationModel
                    .Select(u => new AdministrationModel
                    {
                        Id = u.Id,
                        Active = u.Active,
                        UserId = u.UserId,
                        UserName = u.UserName,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Mobile = u.Mobile,
                        DepartmentId = u.DepartmentId,
                        Departments = u.Departments,
                        RoleId = u.RoleId,
                        Role = u.Role,
                        Roles = u.Roles.ToList(),

                        //.Where(ur => ur.UserId == u.Id)
                        //.Join(_roleManager.Roles, rm => rm.RoleId, ur => ur.Id, (ur, r) => r.Name)
                        //.FirstOrDefault(),
                    }).ToList(),
            };
            return model;
        }

        //}
        public async Task<IActionResult> Index()
        {
			ShareDataModel model = await SyncSharedDataIdentityAsync();

            var sharedData = new ShareDataModel
            {
                IdentityUserAndRoleList = (_context.AdministrationModel == null) ? new List<AdministrationModel>() : _context.AdministrationModel.ToList(),
            };

            return View(sharedData);
        }



        // GET: AdministrationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrationModel = await _context.AdministrationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrationModel == null)
            {
                return NotFound();
            }

            return View(administrationModel);
        }

        // GET: AdministrationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministrationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,UserName,Name,Mobile,Department,Role")] AdministrationModel administrationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrationModel);
        }

        // GET: AdministrationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShareDataModel sharedData = await SyncSharedDataIdentityAsync();
            var model = GetSharedDataIdentity();
            //var sharedData = new ShareDataModel
            //{
            //    IdentityUserAndRoleList = (_context.AdministrationModel == null) ? new List<AdministrationModel>() : await _context.AdministrationModel.FindAsync(id),
            //};

            ShareDataModel ChoosedUser = new ShareDataModel
            {
                IdentityUserAndRoleList = model.IdentityUserAndRoleList
                                                         .Where(u => u.Id == id)
                                                         .ToList(),
            };


            //ShareDataModel model = null;
            //model.IdentityUserAndRoleList = sharedData.IdentityUserAndRoleList
            //                                     .Where(u => u.Id == id)
            //                                     .ToList();
            //            ShareDataModel shareDataModel = 
            //            var administrationModel = await _context.AdministrationModel.FindAsync(id);

            //if (administrationModel == null)
            //         {
            //             return NotFound();
            //         }
            return View(ChoosedUser);
//            return View(administrationModel);
        }

        // POST: AdministrationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,UserName,Name,Mobile,Department,Role")] AdministrationModel administrationModel)
        {
            if (id != administrationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					var existingUser = await _userManager.FindByIdAsync(administrationModel.UserId);
					if (existingUser != null)
					{
						_context.Update(administrationModel);
					}
					else
					{
						_context.Add(administrationModel);
					}

//					_context.Update(administrationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrationModelExists(administrationModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(administrationModel);
        }

        // GET: AdministrationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrationModel = await _context.AdministrationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrationModel == null)
            {
                return NotFound();
            }

            return View(administrationModel);
        }

        // POST: AdministrationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrationModel = await _context.AdministrationModel.FindAsync(id);
            if (administrationModel != null)
            {
                _context.AdministrationModel.Remove(administrationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrationModelExists(int id)
        {
            return _context.AdministrationModel.Any(e => e.Id == id);
        }
    }
}
