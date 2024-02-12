using System.ComponentModel.DataAnnotations;

namespace FireCodingDesign.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDoneDate { get; set; }
        [Display(Name = "Order status")]
        public string? OrderStatus { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
