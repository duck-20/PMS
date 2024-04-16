using System.ComponentModel.DataAnnotations;

namespace PMS.Models
{
	public class Group
	{
		public int GroupId { get; set; }
		[Required(ErrorMessage ="*Please Enter Group Name")]
		public string Name { get; set; }=string.Empty;
		public int? NoOfMedicine { get; set; }
	}
}
