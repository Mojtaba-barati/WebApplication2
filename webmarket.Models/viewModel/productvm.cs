using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webmarket.Models.viewModel
{
	public class productvm
    {
        [ValidateNever]
        public product product { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> categorylist { get; set; }




    }
}
