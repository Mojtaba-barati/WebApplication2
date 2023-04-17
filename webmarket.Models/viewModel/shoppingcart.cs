using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webmarket.Models.viewModel
{
	public  class  shoppingcart
	{
  //      public shoppingcart(double cartTotal, IEnumerable<shopingcard> listcards)
		//{
		//	CartTotal = cartTotal;
		//	this.listcards = listcards;
		//}

		public double CartTotal { get; set; }

        public  IEnumerable <shopingcard> listcards { get; set; }

    }
}
