using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class AddEmployeeViewModel //called this view model so we know it only works with a view
    {
        [Required(ErrorMessage = "Please enter the first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; } //what they actually pick

        public List<SelectListItem> Departments { get; set; }  //a list to pick from

    }
}