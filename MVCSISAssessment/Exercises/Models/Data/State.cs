using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "Please enter the two charater State abbreviation.")]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "Please enter the name of the State.")]
        public string StateName { get; set; }
        public int StateID { get; set; }
    }
}