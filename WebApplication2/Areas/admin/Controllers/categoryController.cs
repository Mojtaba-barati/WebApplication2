using Microsoft.AspNetCore.Mvc;
using webmarket.AccesData;
using webmarket.AccesData.services;
using webmarket.Models;

namespace WebApplication2.Areas.admin.Controllers
{
	[Area("admin")]
    public class categoryController : Controller
    {

        private readonly ipcategory _db;

        public categoryController(ipcategory db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
         
            IEnumerable<catigory> catigory =_db.GetAll();
            return View(catigory);
        }
        public IActionResult creat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult creat(catigory obj)
        {
            if (obj.name == obj.desplayorder)
            {
                ModelState.AddModelError("name", "نباید باهم برابر باشند");
            }
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
            var category1 = _db.getFirstOrDefault(x => x.id == id);
            if (category1 == null)
            {
                return NotFound();
            }
            return View(category1);
        }
        [HttpPost]
        public IActionResult edit(catigory obj)
        {
            if (obj.name == obj.desplayorder)
            {
                ModelState.AddModelError("name", "نباید باهم برابر باشند");
            }
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
            var category1 = _db.getFirstOrDefault(x => x.id == id);
            if (category1 != null && category1.id == id)
            {
                TempData["succes"] = "succes";
                _db.remove(category1);

                return RedirectToAction("index");
            }
            return NotFound();


        }
    }
}
