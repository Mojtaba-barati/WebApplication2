using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
