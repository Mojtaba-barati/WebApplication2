using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webmarket.Models
{
	public class company
	{
		[Key]
		public int Id { get; set; }

		[Display (Name = "نام")]
		public string Name { get; set; }


		[Display (Name = "آدرس خیابان")]
		public string? Streepaddress { get; set; }

		[Display(Name = "شهر")]
		public string? city { get; set; }

		[Display(Name = "شماره تلفن")]
		public string? phonenumber { get; set; }



	}
}
