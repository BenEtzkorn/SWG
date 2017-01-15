using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers //thisis pure C#, you can add anything you want, it is not limited to MVC methods
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepository.GetAll()
                                                join department in DepartmentRepository.GetAll()
                                                on employee.DepartmentId equals department.DepartmentId
                                                select new EmployeeListViewModel()
                                                {
                                                    Name = employee.FirstName + " " + employee.LastName,
                                                    Department = department.DepartmentName,
                                                    Phone = employee.Phone,
                                                    EmployeeID = employee.EmployeeId
                                                };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();

            model.Departments = GetDepartmentsSelectList(); //replaced code with method at end to save repeating

            //model.Departments = (from department in DepartmentRepository.GetAll()
            //                     select new SelectListItem()
            //                     {
            //                         Text = department.DepartmentName,
            //                         Value = department.DepartmentId.ToString(),
            //                     }).ToList();
                                 
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model) //this is the class and object that we created for the add, so pass into this method.
        {
            if(ModelState.IsValid)
            {
                Employee employee = new Employee(); //we want to create and add an employee, so instantiate it
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Add(employee);

                return RedirectToAction("List"); //end this page and tells browser to go to List instead
            }
            else
            {
                model.Departments = GetDepartmentsSelectList(); //replaced code below with method at end to not repeat

               // model.Departments = (from department in DepartmentRepository.GetAll()
               //                      select new SelectListItem()
               //                      {
               //                         Text = department.DepartmentName,
               //                          Value = department.DepartmentId.ToString(),
               //                      }).ToList();

                return View(model);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = EmployeeRepository.Get(id);

            var model = new EditEmployeeViewModel();  //reverse of add, we went from model to employee, here we go from employee to model
            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.DepartmentId = employee.DepartmentId;
            model.Phone = employee.Phone;
            model.EmployeeId = employee.EmployeeId;

            model.Departments = GetDepartmentsSelectList();  //code below for this method

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.EmployeeId = model.EmployeeId;//must add
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Edit(employee);

                return RedirectToAction("List");
            }
            else
            {
                model.Departments = GetDepartmentsSelectList();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeRepository.Delete(id);
            return RedirectToAction("List");
        }

        private List<SelectListItem> GetDepartmentsSelectList() //using this over and over again, so replacing code above with it
        {
            return (from department in DepartmentRepository.GetAll()
                    select new SelectListItem()
                    {
                        Text = department.DepartmentName,
                        Value = department.DepartmentId.ToString()
                    }).ToList();
        }
    }
}