using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FireCodingDesign.Controllers
{
    [Authorize]
    // Andra egenskaper i din Order-klass
    public class OrdersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        //        public OrdersController(ApplicationDbContext context)
        public OrdersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // Index()
        // GET: Orders
        public IActionResult Index()
        {
            var orders = _context.Order.ToList();

            var orderViewModels = orders.Select(order => new Order
            {
                CustomerName = order.CustomerName,
                Description = order.Description,
                ImageContentType = order.ImageContentType,
                ImageData = order.ImageData,
                OrderDate = order.OrderDate,
                OrderDoneDate = order.OrderDoneDate,
                OrderNumber = order.OrderNumber,
                ImageDataThumbnail = ConvertImageToBase64(order.ImageData),
                DepartmentId = order.DepartmentId,
                Departments = _context.Department.ToList()
            }).ToList();

            return View(orderViewModels);
        }
        //var applicationDbContext = _context.Order.Include(o => o.Customer);
        //return View(await applicationDbContext.ToListAsync());


        // Details()
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderNumber == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            // Hämtar den inloggade användarens id
            var userId = _userManager.GetUserId(User);
            // Hämtar användaren från databasen
            var user = _userManager.FindByIdAsync(userId).Result;

            //           var user = _userManager.FindByIdAsync(userId).Result; ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View(new Order { CustomerName = user.ToString() });
        }
        private string ConvertImageToBase64(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                return $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
            }
            return string.Empty;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderNumber,Description,OrderDate,OrderDoneDate,OrderStatus,ImageFile,ImageData,DepartmentId,CustomerName,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
              order.DepartmentId = 7;
              if (order.ImageFile != null && order.ImageFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await order.ImageFile.CopyToAsync(stream);
                        order.ImageData = stream.ToArray();
                        order.ImageContentType = order.ImageFile.ContentType;
                    }
                }

                _context.Add(order);
                await _context.SaveChangesAsync();
                ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
                return RedirectToAction(nameof(Index));
                return View(order);
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);

        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //            Order order = _context.Order.Include(o => o.Departments).FirstOrDefault(o => o.OrderNumber == id);
            //            order.Departments = _context.Department.ToList();

            //            if (id == null)
            //            {
            //                return NotFound();
            //            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerName"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerName);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderNumber,Description,OrderDate,OrderDoneDate,OrderStatus,ImageFile,ImageData,ImageContentType,CustomerName,CustomerId")] Order order)
        {
            if (id != order.OrderNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderNumber))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderNumber == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderNumber == id);
        }
    }
}


//    public class OrdersController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public OrdersController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//// Index()
//// GET: Orders
//        public async Task<IActionResult> Index()
//        {
//            var applicationDbContext = _context.Order.Include(o => o.Customer);
//            return View(await applicationDbContext.ToListAsync());
//        }

//// Details()
//// GET: Orders/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var order = await _context.Order
//                .Include(o => o.Customer)
//                .FirstOrDefaultAsync(m => m.OrderNumber == id);
//            if (order == null)
//            {
//                return NotFound();
//            }

//            return View(order);
//        }

//        // GET: Orders/Create
//        public IActionResult Create()
//        {
//            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
//            return View();
//        }

//        // POST: Orders/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("OrderNumber,Description,OrderDate,OrderDoneDate,OrderStatus,CustomerId")] Order order)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(order);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
//            return View(order);
//        }

//        // GET: Orders/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var order = await _context.Order.FindAsync(id);
//            if (order == null)
//            {
//                return NotFound();
//            }
//            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
//            return View(order);
//        }

//        // POST: Orders/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("OrderNumber,Description,OrderDate,OrderDoneDate,OrderStatus,CustomerId")] Order order)
//        {
//            if (id != order.OrderNumber)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(order);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!OrderExists(order.OrderNumber))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
//            return View(order);
//        }

//        // GET: Orders/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var order = await _context.Order
//                .Include(o => o.Customer)
//                .FirstOrDefaultAsync(m => m.OrderNumber == id);
//            if (order == null)
//            {
//                return NotFound();
//            }

//            return View(order);
//        }

//        // POST: Orders/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var order = await _context.Order.FindAsync(id);
//            if (order != null)
//            {
//                _context.Order.Remove(order);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool OrderExists(int id)
//        {
//            return _context.Order.Any(e => e.OrderNumber == id);
//        }
//    }
//}
