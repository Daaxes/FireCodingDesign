using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCodingDesign.Models
{

    public class Order : IValidatableObject
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
        [DisplayName("Orderd by")]
        public string? CustomerName { get; set; }
        [Display(Name = "Bild")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageContentType { get; set; }
        [Display(Name = "Thumbnail")]
        public string? ImageDataThumbnail { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }      // ändrat
        public List<Department>? Departments { get; set; }
        public string? DepartmentName => Departments?.FirstOrDefault(d => d.Id == DepartmentId)?.DepartmentDescription; // ändrat

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (OrderDate.HasValue && OrderDate < DateTime.Today)
            {
                results.Add(new ValidationResult("Order date cannot be earlier than today.", new[] { nameof(OrderDate) }));
            }

            if (OrderDoneDate.HasValue)
            {
                if (OrderDoneDate < DateTime.Today)
                {
                    results.Add(new ValidationResult("Order done date cannot be earlier than today.", new[] { nameof(OrderDoneDate) }));
                }

                if (OrderDoneDate < OrderDate)
                {
                    results.Add(new ValidationResult("Order done date cannot be earlier than order date.", new[] { nameof(OrderDoneDate) }));
                }
            }

            return results;
        }
    }

    //public class Order
    //{
    //    [Key]
    //    public int OrderNumber { get; set; }
    //    public string? Description { get; set; }
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? OrderDate { get; set; }
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? OrderDoneDate { get; set; }
    //    [Display(Name = "Order status")]
    //    public string? OrderStatus { get; set; }
    //    public int? CustomerId { get; set; }
    //    public Customer? Customer { get; set; }
    //}
}
