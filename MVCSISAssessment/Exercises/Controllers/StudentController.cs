using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            if(studentVM.Student.Courses.Count == 0)
            {
               
                ModelState.AddModelError("Courses", "Please select at least one course.");
                return View(studentVM);
                
            }

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            if (string.IsNullOrEmpty(studentVM.Student.Major.MajorName) )
            {

                ModelState.AddModelError("MajorName", "Please select a major.");
                return View(studentVM);

            }

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
                
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var viewModel = new EditVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.Student = viewModel.GetStudent(Id);
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditVM editVM)
        {
            EditVM.Edit(editVM);
            return RedirectToAction("List");
        }

        //[HttpPost]
        //public ActionResult Edit(EditVM editVM)
        //{
        //    editVM.Student.Courses = new List<Course>();

        //    foreach (var id in editVM.SelectedCourseIds)
        //        editVM.Student.Courses.Add(CourseRepository.Get(id));

        //    if (editVM.Student.Courses.Count == 0)
        //    {

        //        ModelState.AddModelError("Courses", "Please select at least one course.");
        //        return View(editVM);

        //    }

        //    editVM.Student.Major = MajorRepository.Get(editVM.Student.Major.MajorId);

        //    if (string.IsNullOrEmpty(editVM.Student.Major.MajorName))
        //    {

        //        ModelState.AddModelError("MajorName", "Please select a major.");
        //        return View(editVM);

        //    }

        //    return RedirectToAction("List");
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}