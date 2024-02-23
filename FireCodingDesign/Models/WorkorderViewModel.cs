using Microsoft.Data.SqlClient;

namespace FireCodingDesign.Models
{
    public class WorkorderViewModel : WorkOrder
    {
        public List<WorkOrder> Workorders { get; set; }
        public List<Department> Departments { get; set; }
        public int? SelectedDepartmentId { get; set; }

    }
}
