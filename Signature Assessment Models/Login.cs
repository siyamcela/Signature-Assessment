using System;
using System.ComponentModel.DataAnnotations;

namespace Signature_Assessment_Models
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
