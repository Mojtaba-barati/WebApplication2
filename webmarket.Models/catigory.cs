
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webmarket.Models
{
    public class catigory
	{
        public int id { get; set; }
        [Required(ErrorMessage = "عنوان دسته اجباری است")]
        [DisplayName("عنوان دسته")]
        public string name { get; set; }
        [Required(ErrorMessage = "ترتیب دسته اجباری است")]
        [DisplayName("ترتیب نمایش")]

        public string desplayorder { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;

    }
}
