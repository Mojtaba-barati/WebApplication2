using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webmarket.Models
{
    public class applicationuser : IdentityUser
    {
        public string fullname { get; set; }

        public string? address { get; set; }

        public int? compony { get; set; }
        [ForeignKey("compony")]
        [ValidateNever]

        public company company { get; set; }


    }
}
