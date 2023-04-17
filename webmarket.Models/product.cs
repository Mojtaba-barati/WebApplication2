using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webmarket.Models
{
    public class product
    {
        [Key]
		[ValidateNever]
		public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن  عنوان اجباریست")]
        [DisplayName("عنوان")]
        [MaxLength(100, ErrorMessage = " نباید بیشتر از 100  کاراکتر باشد")]
        
        public string title { get; set; }
        [Required(ErrorMessage = "وارد کردن توضیحات الزامی است")]
        [DisplayName("توضیحات")]
        [MaxLength(500, ErrorMessage = " نباید بیشتر از 500  کاراکتر باشد")]
		[ValidateNever]
		public string Description { get; set; }
        [Required(ErrorMessage = "وارد کردن شناسه کتاب الزامی است")]
        [DisplayName("شناسه")]
        [MaxLength(250, ErrorMessage = " نباید بیشتر از 250  کاراکتر باشد")]


        public string isbn { get; set; }
        [Required(ErrorMessage = "وارد کردن  نویسنده اجباریست")]
        [DisplayName("نویسنده")]
        [MaxLength(200,ErrorMessage=" نباید بیشتر از 200  کاراکتر باشد")]


        public string another { get; set;}
        [Required(ErrorMessage = "لیست قیمت ها اجباریست")]
        [DisplayName("لیست قیمت ها")]
      




        public double listprice { get; set; }

        [Required(ErrorMessage = "قیمت اجباریست")]
        [DisplayName("قیمت")]
       


        public double price { get; set; }
        [Required(ErrorMessage = "قیمت 50 عدد اجباریست")]
        [DisplayName("قیمت 50عدد")]
       


        public double price50 { get; set; }
        [Required(ErrorMessage = "قیمت 100 اجباریست")]
        [DisplayName("قیمت 100عدد")]
        


        public double price100 { get; set; }
        [Required(ErrorMessage = "شناسه عکس اجباریست")]
        [DisplayName("شناسه عکس کتاب")]
        [ValidateNever]


        public string imgurl { get; set; }
        [Required(ErrorMessage = "دسته اجباریست")]
        [DisplayName("دسته")]
		[ValidateNever]


		public int categoryid { get; set; }

        [ForeignKey ("categoryid")]
        public  catigory category { get; set; }


       
    }

}
