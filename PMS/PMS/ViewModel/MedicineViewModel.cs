using PMS.Models;

namespace PMS.ViewModel
{
	public class MedicineViewModel
	{
		public IEnumerable<Group> Groups { get; set; }=new List<Group>();
		public Medicine Medicine { get; set; }=new Medicine();
	}
}
