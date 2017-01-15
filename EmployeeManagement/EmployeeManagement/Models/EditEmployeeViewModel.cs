using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Models
{
    public class EditEmployeeViewModel //could just inherit add emplioyee model and add the department ID, but not ideal, best to make an independent controller for each
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter the first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }

        public List<SelectListItem> Departments { get; set; }
    }
}