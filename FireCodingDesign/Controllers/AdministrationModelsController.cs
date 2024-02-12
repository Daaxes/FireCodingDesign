using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FireCodingDesign.Data;
using FireCodingDesign.Models;

namespace FireCodingDesign.Controllers
{
    public class AdministrationModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministrationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdministrationModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdministrationModel.ToListAsync());
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

            var administrationModel = await _context.AdministrationModel.FindAsync(id);
            if (administrationModel == null)
            {
                return NotFound();
            }
            return View(administrationModel);
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
                    _context.Update(administrationModel);
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
