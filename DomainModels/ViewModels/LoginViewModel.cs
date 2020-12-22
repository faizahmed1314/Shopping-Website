using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please Enter your User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter your User Name")]
        public string Password { get; set; }
    }
}
