using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webmarket.AccesData.services;
using webmarket.Models;
using webmarket.Models.viewModel;


namespace WebApplication2.Areas.customer.Controllers


{
	[Area("customer")]
   


	public class Cart : Controller
    {
		

		private readonly IOrderHeaderService orderHeaderService;
        private readonly SignInManager<IdentityUser> _singInManeger;
        private readonly ishopingcard _ishopingcard;
        


        public Cart(IOrderHeaderService orderHeaderService, SignInManager<IdentityUser> _singInManeger, ishopingcard ishopingcard)
        {
            this.orderHeaderService = orderHeaderService;
            this._singInManeger = _singInManeger;
            this._ishopingcard = ishopingcard;
          
        }

        
        public int ordertotal { get; set; }


        [HttpGet]
        public IActionResult Index()
        {

            var user = _singInManeger.UserManager.FindByNameAsync(User.Identity.Name).Result;


            shoppingcart shopingcards = new shoppingcart()
            {
                listcards = _ishopingcard.GetAll(user.Id)

            };

            foreach (var cart in shopingcards.listcards)
            {
                cart.price = (int)GetPriceBasedOnQuantity(cart.count, cart.product.price, cart.product.price50, cart.product.price100);
                shopingcards.CartTotal += (cart.price * cart.count);
            }



            return View(shopingcards);
        }

        private double GetPriceBasedOnQuantity(int quantity, double price, double price50, double price100)
        {
            if (quantity <= 50)
            {
                return price;
            }
            else
            {
                if (quantity <= 100)
                {
                    return price50;
                }
                else
                {
                    return price100;
                }
            }

        }

    }
}
