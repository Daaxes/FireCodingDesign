using FireCodingDesign.Data;
using FireCodingDesign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FireCodingDesign.Controllers
{
    public class WorkOrderController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        // GET: WorkordersController1
        public ActionResult Index()
        {
            var workorders = _context.Order.ToList();

            var workorderView = workorders.Select(order => new WorkOrder
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

            return View(workorderView);
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
