using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class Address
    {
        
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Please enter the Student's street address.")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage = "Please enter the Student's city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the Student's state.")]
        public State State { get; set; }
        [Required(ErrorMessage = "Please enter the Student's zip code.")]
        public string PostalCode { get; set; }
    }
}