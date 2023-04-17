using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webmarket.AccesData;
using webmarket.AccesData.services;
using webmarket.Models;
using webmarket.Models.viewModel;

namespace WebApplication2.Areas.admin.Controllers
{
	[Area("admin")]
	public class shopingcardController: Controller
	{
		private readonly ishopingcard _db;


        public shopingcardController(ishopingcard shopingcard)

        {
			_db = shopingcard;           

        }
		public IActionResult Index()
		{
			  

			return View(_db.getAll());
		}
		
		
		//[HttpPost]
		//public IActionResult upsert(shopingcard obj)
		//{
			
		//	if (ModelState.IsValid)
		//	{

				
		//			_db.update(obj);
				



		//		TempData["succes"] = "succes";
		//		return RedirectToAction("Index");

		//	}
		//	return View(obj);

		//}


		//[HttpPost]
		//public ActionResult GetAll()
		//{
		//	var res = _db.GetAll();

		//	return Json(res);
		//}
		
		//public ActionResult Delete(int Id)
		//{

		//	var obj = _db.getFirstOrDefault(x => x.Id == Id);
		//	if (obj != null && obj.Id == Id)
		//	{
		//		TempData["succes"] = "succes";
		//		var oldImagepath = Path.Combine(webHostEnvironment.WebRootPath, obj.imgurl.TrimStart('\\'));
		//		if (System.IO.File.Exists(oldImagepath))
		//		{
		//			System.IO.File.Delete(oldImagepath);
		//		}
		//		_db.remove(obj);
				
		//		return Json(new { success = true, message = "موفقیت آمیز بود" });
		//	}
		//	else
		//	{
		//		return Json(new { success = false, message = "خطا در برقراری ارتباط" });
		//	}
			


		//}
	}
}
