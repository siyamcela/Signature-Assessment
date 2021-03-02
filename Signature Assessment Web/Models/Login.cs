using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Signature_Assessment_Web.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Please enter a User name")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Please enter a Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

    }
}