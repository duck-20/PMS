using Microsoft.AspNetCore.Mvc;
using PMS.Models;

namespace PMS.Controllers
{
	public class GroupController : Controller
	{
		public IActionResult Index()
		{
			var groups=GroupRepository.GetGroups();
			return View(groups);
		}
		public IActionResult Edit(int? id)
		{
			ViewBag.Action = "Edit";
			var group=GroupRepository.GetGroupById(id:id.HasValue?id.Value:0);
			return View(group);
		}
		[HttpPost]
		public IActionResult Edit(Group group)
		{
			if(ModelState.IsValid) 
			{
				ViewBag.isSuccess=true;
				ModelState.Clear();
				GroupRepository.UpdateGroupById(group.GroupId, group);
				return View();
			}
			return View(group);
			
		}
		public IActionResult Delete(int id)
		{
			GroupRepository.DeleteGroupById(id);
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View();
		}
		[HttpPost]
		public IActionResult Add(Group group)
		{
			if(ModelState.IsValid)
			{
				ViewBag.isSuccess = true;
				ModelState.Clear();
				GroupRepository.AddGroup(group);
				return View();
			}
			return View(group);
		}
	}
}
