using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webmarket.Models
{
	public class shopingcard
	{
		[Key]
		public int Id { get; set; }

		public int productid { get; set; }
		[ForeignKey("productid")]
		[ValidateNever]
		public product product { get; set; }

		public string applicationuserid { get; set; }

		[ForeignKey("applicationuserid")]
		[ValidateNever]

		public applicationuser applicationuser { get; set; }


		[Range(1,100, ErrorMessage ="لطفا تعداد محصول را بین 1تا 100 وارد کنید")]
		public int count { get; set; }


		public int price { get; set; }


	}
}
