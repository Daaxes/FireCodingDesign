using FireCodingDesign.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System;

namespace FireCodingDesign.Models
{
    public class ShareDataModel
    {
        public List<Customer>? CustomerList { get; set; } = new List<Customer>();
        public List<Company>? CompanyList { get; set; } = new List<Company>();
        public List<Provider>? ProviderList { get; set; } = new List<Provider>();
        public List<Order>? OrderList { get; set; }
        public List<IdentityRole>? IdentityRolesList { get; set; }
        public List<IdentityUser>? IdentityUsersList { get; set; }
        public List<AdministrationModel>? IdentityUserAndRoleList { get; set; }
        public List<Department>? DepartmentsList { get; set; }

        public void clear()
        {
            CustomerList = null;//.Clear();
            CompanyList = null;
            ProviderList = null;
            OrderList = null;
            //            IdentityList = null;
        }

    //    public static implicit operator ShareDataModel(ShareDataModel v)
    //    {
    //        throw new NotImplementedException();
    //    }
    }
}
//public class ShareDataModel
//{
//    // Andra egenskaper i ShareDataModel

//    public List<Department> DepartmentsList { get; set; }
//}
//Uppdatera Edit Action i din Controller för att inkludera avdelningslistan när du skapar ShareDataModel:

//csharp
//Copy code
//public IActionResult Edit(int id)
//{
//    var administrationModel = // Hämta administrationModel baserat på id
//    var departmentsList = _context.Departments.ToList(); // Hämta alla avdelningar från din databas

//    var model = new ShareDataModel
//    {
//        AdministrationModel = administrationModel,
//        DepartmentsList = departmentsList
//    };

//    return View(model);
//}
//Uppdatera Edit View för att använda DepartmentsList från ShareDataModel:

//html
//Copy code
//@model ShareDataModel

//<!-- Annan kod här -->

//<div class= "form-group" >
//    < label asp -for= "AdministrationModel.DepartmentId" class= "control-label" ></ label >
//    < select asp -for= "AdministrationModel.DepartmentId" asp - items = 'new SelectList(Model.DepartmentsList, "Id", "DepartmentName", Model.AdministrationModel.DepartmentId)' class= "form-control" ></ select >
//    < span asp - validation -for= "AdministrationModel.DepartmentId" class= "text-danger" ></ span >
//</ div >

//< !--Annan kod här -->