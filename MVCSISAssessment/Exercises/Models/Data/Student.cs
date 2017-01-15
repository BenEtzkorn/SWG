using Exercises.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        [Required(ErrorMessage = "Please enter your major.")]
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
        public EditVM EditVM { get; set; }
               
    }
}