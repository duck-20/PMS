using System.ComponentModel.DataAnnotations;

namespace PMS.Models
{
	public class Medicine
	{
		public int MedicineId { get; set; }
		[Required]
		[Display(Name = "Group")]
		public int? GroupId { get; set; }
		[Required(ErrorMessage ="* Enter Medicine Name")]
		public string Name { get; set; } = string.Empty;
		public string Description { get; set;} = string.Empty;
		[Required(ErrorMessage ="*Enter Medicine Price")]
		[Range(0,int.MaxValue)]
		public double? Price { get; set; }
		[Required(ErrorMessage = "*Enter Number of Medicine")]
		[Range(1, int.MaxValue)]
		public int? Quantity {  get; set; }
		public Group? Group { get; set; }
		[Required(ErrorMessage ="*State Expiry Date")]
		public DateOnly? ExpiryDate { get; set; }

	}
}
