using Microsoft.AspNetCore.Identity;

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
//        public List<UserWithRoleModel>? IdentityUserAndRoleList { get; set; }
        public void clear()
        {
            CustomerList = null;//.Clear();
            CompanyList = null;
            ProviderList = null;
            OrderList = null;
            //            IdentityList = null;
        }

    }
}
