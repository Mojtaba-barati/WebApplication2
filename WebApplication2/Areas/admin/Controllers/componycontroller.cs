using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;
using webmarket.AccesData;
using webmarket.AccesData.services;
using webmarket.Models;

namespace WebApplication2.Areas.admin.Controllers
{
	[Area("admin")]
	public class componycontroller : Controller
	{

		private  readonly icompany _db;

		
		

		public componycontroller(icompany db)
		{
			_db = db;
			

		}

		public IActionResult Index()
		{

			return View(_db.GetAll());
		}
		public IActionResult creat()
		{
			return View();
		}
		[HttpPost]
		public IActionResult creat(company obj)
		{
			
			if (ModelState.IsValid)
			{
				TempData["succes"] = "succes";

				_db.Add(obj);

				return RedirectToAction("Index");
			}
			return View(obj);
		}
		public IActionResult edit(int id)
		{
			if (id == 0 || id.ToString() == null)
			{
				return NotFound();
			}
			var company = _db.getFirstOrDefault(x => x.Id == id);
			if (company == null)
			{
				return NotFound();
			}
			return View(company);
		}
		[HttpPost]
		public IActionResult edit(company obj)
		{
			//if (obj.name == obj.desplayorder)
			//{
			//	ModelState.AddModelError("name", "نباید باهم برابر باشند");
			//}
			if (ModelState.IsValid)
			{
				TempData["succes"] = "succes";

				_db.update(obj);


				return RedirectToAction("Index");

			}
			return View(obj);

		}
		public IActionResult remove(int id)
		{
			if (id == 0 || id.ToString() == null)
			{
				return NotFound();
			}
			var category1 = _db.getFirstOrDefault(x => x.Id == id);
			if (category1 != null && category1.Id == id)
			{
				TempData["succes"] = "succes";
				_db.remove(category1);

				return RedirectToAction("index");
			}
			return NotFound();


		}
		
	}
}
