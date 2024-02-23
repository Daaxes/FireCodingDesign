using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace FireCodingDesign.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, PowerUser, Owner, User")]

    public class WorkOrderController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        // GET: WorkordersController1
        public ActionResult Index(int? departmentId)
        {
            var ordersWithDepartmentInfo = _context.Order.Include(o => o.Department).ToList();
            var workOrders = new List<WorkOrder>();
//            var existingOrderNumbers = _context.WorkOrder;

            // Skapa arbetsordrar och inkludera avdelnings- och orderinformation
            foreach (var order in ordersWithDepartmentInfo)
            {
                bool orderNumberExists = _context.WorkOrder.Any(w => w.OrderNumber == order.OrderNumber);
                if (!orderNumberExists)
                { 
                    var workOrder = new WorkOrder
                    {
                        OrderNumber = order.OrderNumber,
                        WorkOrders = new List<Order> { order },
                        CustomerName = order.CustomerName,
                        Description = order.Description,
                        OrderDate = order.OrderDate,
                        OrderDoneDate = order.OrderDoneDate,
                        ImageFile = order.ImageFile,
                        ImageData = order.ImageData,
                        ImageContentType = order.ImageContentType,
                        ImageDataThumbnail = ConvertImageToBase64(order.ImageData),
                        DepartmentId = order.DepartmentId,
                        Departments = _context.Department.ToList()
    //                                        WorkOrderName = order.OrderName,
                    };

                    workOrders.Add(workOrder);
                }
            }

            _context.WorkOrder.AddRange(workOrders);
            _context.SaveChanges();
            workOrders = _context.WorkOrder.ToList();
            foreach(var workorder in workOrders)
            {
                workorder.Departments = _context.Department.ToList();
            }

            List<WorkOrder> model;

            if (departmentId == null)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userDepartmentName = _context.AdministrationModel.FirstOrDefault(u => u.UserId == userId).DepartmentName;
                var userDepartmentId = _context.Department.FirstOrDefault(ui => ui.DepartmentName == userDepartmentName).Id;
                model = workOrders.Where(wo => wo.DepartmentId == userDepartmentId).ToList();

                if (model.Count == 0)
                {
                    var emptyWorkOrder = new WorkOrder
                    {
                        Departments = workOrders.FirstOrDefault()?.Departments ?? new List<Department>(),
                        DepartmentId = userDepartmentId
                        //                    DepartmentName = userDepartmentName
                    };

                    model.Add(emptyWorkOrder);
                }
            }
            else
            {
//                var userDepartmentId = _context.Department.FirstOrDefault(ui => ui.DepartmentName == userDepartmentName).Id;
                model = workOrders.Where(wo => wo.DepartmentId == departmentId).ToList();

                if (model.Count == 0)
                {
                    var emptyWorkOrder = new WorkOrder
                    {
                        Departments = workOrders.FirstOrDefault()?.Departments ?? new List<Department>(),
                        DepartmentId = departmentId
                        //                    DepartmentName = userDepartmentName
                    };

                    model.Add(emptyWorkOrder);
                }

            }

            //            model.Add(new workOrders.FirstOrDefault().Departments);

            return View(model);
//            return View(workorderView);
            //            return View();
        }

        // GET: WorkordersController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkordersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkordersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
            WorkOrder workorder = new WorkOrder();
            workorder.OrderNumber = order.OrderNumber;
            workorder.OrderDate = order.OrderDate;
            workorder.OrderDoneDate = order.OrderDoneDate;
            workorder.DepartmentId = order.DepartmentId;
            workorder.Departments = _context.Department.ToList();
            workorder.CustomerName = order.CustomerName;
            workorder.Description = order.Description;
            workorder.ImageContentType = order.ImageContentType;
            workorder.ImageDataThumbnail = order.ImageDataThumbnail;
            workorder.ImageData = order.ImageData;
            workorder.ImageFile = order.ImageFile;
            

            if (workorder == null)
            {
                return NotFound();
            }
            ViewData["CustomerName"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", workorder.CustomerName);
            return View(workorder);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderNumber,Description,OrderDate,OrderDoneDate,OrderStatus,ImageFile,ImageData,ImageContentType,CustomerName,CustomerId")] WorkOrder workorder)
        {
            if (id != workorder.OrderNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(workorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workorder.OrderNumber))
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
 //           ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", workorder.CustomerId);
            return View(workorder);
        }

        private bool WorkOrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderNumber == id);
        }

        // GET: WorkordersController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkordersController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string ConvertImageToBase64(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                return $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
            }
            return string.Empty;
        }

    }
}
