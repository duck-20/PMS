using Microsoft.AspNetCore.Mvc;
using PMS.Models;
using PMS.ViewModel;

namespace PMS.Controllers
{
	public class MedicineController : Controller
	{
		public IActionResult Index()
		{ 
			var meds=MedicineRepository.GetMedicines(loadGroup:true);
			return View(meds);
		}
		public IActionResult Add()
		{
			MedicineViewModel medicines = new MedicineViewModel()
			{
				Groups = GroupRepository.GetGroups()
			};
			return View(medicines);
		}
		[HttpPost]
		public IActionResult Add(MedicineViewModel model)
		{
			if (ModelState.IsValid)
			{
				MedicineRepository.AddMedicine(model.Medicine);
				return RedirectToAction(nameof(Index));
			}
			model.Groups = GroupRepository.GetGroups();
			return View(model);
		}
		public IActionResult Details(int id)
		{
			var med=MedicineRepository.GetMedicineById(id,loadGroup:true);
			return View(med);
		}
		public IActionResult Edit(int id)
		{
			MedicineViewModel medicineViewModel = new MedicineViewModel()
			{
				Groups = GroupRepository.GetGroups(),
				Medicine = MedicineRepository.GetMedicineById(id) ?? new Medicine()
				
			};
			return View(medicineViewModel);
		}
		[HttpPost]
		public IActionResult Edit(MedicineViewModel model)
		{
			if(ModelState.IsValid)
			{
				MedicineRepository.UpdateMedicineById(model.Medicine.MedicineId,model.Medicine);
				return RedirectToAction(nameof(Index));
			}
			model.Groups = GroupRepository.GetGroups();
			return View(model);
		}
		public IActionResult Delete(int id)
		{
			MedicineRepository.DeleteMedicineById(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
