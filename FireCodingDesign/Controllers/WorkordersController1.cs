using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FireCodingDesign.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, PowerUser, Owner, User")]

    public class WorkOrderController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        // GET: WorkordersController1
        public ActionResult Index()
        {
            var ordersWithDepartmentInfo = _context.Order.Include(o => o.Department).ToList();
            var workOrders = new List<WorkOrder>();

            // Skapa arbetsordrar och inkludera avdelnings- och orderinformation
            foreach (var order in ordersWithDepartmentInfo)
            {
                var workOrder = new WorkOrder
                {
                    WorkOrderId = order.OrderNumber,
                    WorkOrders = new List<Order> { order },
                    CustomerName = order.CustomerName,
                    Description = order.Description,
                    OrderDate = order.OrderDate,
                    OrderDoneDate = order.OrderDoneDate,
                    OrderNumber = order.OrderNumber,
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

            //            var workorders = _context.Order.ToList();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //            var userDepartment = _context.AdministrationModel.FirstOrDefault().DepartmentName;
            var userDepartment = _context.AdministrationModel.FirstOrDefault(u => u.UserId == userId);
                //.Where(u => u.UserId == userId)
                //.Select(u => u.DepartmentName)
                //.FirstOrDefault();

            return View(workOrders);
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

        // GET: WorkordersController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkordersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
