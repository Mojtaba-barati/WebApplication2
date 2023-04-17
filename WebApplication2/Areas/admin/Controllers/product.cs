using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webmarket.AccesData;
using webmarket.AccesData.services;
using webmarket.Models.viewModel;

namespace WebApplication2.Areas.admin.Controllers
{
	[Area("admin")]
	public class product : Controller
	{
		private readonly iproductsservices _db;

		private readonly ipcategory _ipcategory;

		private readonly IWebHostEnvironment webHostEnvironment;

		private readonly applicationDBcontext s;

		public product(iproductsservices db, ipcategory ipcategory, IWebHostEnvironment hostEnvironment, applicationDBcontext ps)
		{
			s = ps;
			webHostEnvironment = hostEnvironment;
			_db = db;
			_ipcategory = ipcategory;
		}
		public IActionResult Index()
		{
			var s=_db.GetAll().ToList();

			return View(s);
		}
		
		public IActionResult upsert(int id)
		{
			productvm productvm = new()
			{
				product = new(),
				categorylist = _ipcategory.GetAll().Select(x => new SelectListItem
				{
					Text = x.name,
					Value = x.id.ToString()
				}),


			};


			if (id == 0 || id.ToString() == null)
			{
				//creat
				ViewBag.id = _ipcategory.GetAll().Select(x => new { x.name });


				return View(productvm);

			}
			else
			{
				//update
				productvm.product = _db.getFirstOrDefault(x => x.Id == id);
				return View(productvm);

			}


		}
		[HttpPost]
		public IActionResult upsert(productvm obj, IFormFile? file)
		{
			string wwwRootpath = webHostEnvironment.WebRootPath;
			if (ModelState.IsValid)
			{

				if (file != null)
				{
					string filename = Guid.NewGuid().ToString();
					var upload = Path.Combine(wwwRootpath, @"img/product");
					var extenstion = Path.GetExtension(file.FileName);
					if (obj.product.imgurl != null)
					{
						var oldImagepath = Path.Combine(wwwRootpath, obj.product.imgurl.TrimStart('\\'));
						if (System.IO.File.Exists(oldImagepath))
						{
							System.IO.File.Delete(oldImagepath);
						}
					}
					using (var filestreams = new FileStream(Path.Combine(upload, filename + extenstion), FileMode.Create))
					{
						file.CopyTo(filestreams);
					}
					obj.product.imgurl =  filename + extenstion;

				}
				var f = _db.getFirstOrDefault(x => x.Id == obj.product.Id);
				if (f == null)
				{
					_db.Add(obj);
					s.SaveChanges();
				}
				else
				{
					_db.update(obj);
				}



				TempData["succes"] = "succes";
				return RedirectToAction("Index");

			}
			return View(obj);

		}


		[HttpPost]
		public ActionResult GetAll()
		{
			var res = _db.GetAll();

			return Json(res);
		}
		
		public ActionResult Delete(int Id)
		{

			var obj = _db.getFirstOrDefault(x => x.Id == Id);
			if (obj != null && obj.Id == Id)
			{
				TempData["succes"] = "succes";
				var oldImagepath = Path.Combine(webHostEnvironment.WebRootPath, obj.imgurl.TrimStart('\\'));
				if (System.IO.File.Exists(oldImagepath))
				{
					System.IO.File.Delete(oldImagepath);
				}
				_db.remove(obj);
				
				return Json(new { success = true, message = "موفقیت آمیز بود" });
			}
			else
			{
				return Json(new { success = false, message = "خطا در برقراری ارتباط" });
			}
			


		}
	}
}
