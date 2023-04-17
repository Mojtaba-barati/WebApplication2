using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webmarket.AccesData;
using webmarket.AccesData.services;
using webmarket.Models;

namespace WebApplication2.Areas.customer.Controllers
{
	[Area("customer")]
	
	public class HomeController : Controller
	{


		private readonly iproductsservices _iproductsservices;

		private readonly ishopingcard _ishopingcards;



		public HomeController(iproductsservices db, ishopingcard ishopingcard)
		{
			_iproductsservices = db;
			_ishopingcards = ishopingcard;

		}

		public IActionResult Index()
		{
			var s = _iproductsservices.GetAll();

			return View(s);
		}
		[HttpGet]
		public IActionResult Details(int id)
		{
			shopingcard shoppingcard = new shopingcard
			{
				product = _iproductsservices.getFirstOrDefault(x => x.Id == id),
				productid = id,
				count = 1

			};
			return View(shoppingcard);

		}
		[HttpPost]
        [Authorize]
        public IActionResult productdetails(shopingcard shopingcard)
		{
			var cliamIdentity = (ClaimsIdentity)User.Identity;
			var claim = cliamIdentity.FindFirst(ClaimTypes.NameIdentifier);
			shopingcard.applicationuserid = claim.Value;

			shopingcard cartfromdb = _ishopingcards.getFirstOrDefault(x => x.productid == shopingcard.productid && x.applicationuserid == claim.Value);

			if (cartfromdb == null)
			{
				_ishopingcards.Add(shopingcard);
			}
			else
			{
				_ishopingcards.IncrementCount(cartfromdb, shopingcard.count);
				
			}
			return Redirect("Index");

		}
	}
}
