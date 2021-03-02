using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signature_Assessment_Models
{
    public  class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public  string LastLogin { get; set; }
        [NotMapped]
        public Info PersonInfo { get; set; }
    }
    public class Persons
    {
      
        public int Id { get; set; }

 
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string LastLogin { get; set; }
        public Info PersonInfo { get; set; }
    }
}
