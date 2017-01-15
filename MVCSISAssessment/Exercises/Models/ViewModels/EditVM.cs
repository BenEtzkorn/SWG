using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Exercises.Models.Data;
using Exercises.Models.Repositories;

namespace Exercises.Models.ViewModels
{



    public class EditVM
    {
        public Student Student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }
        //public int StudentId { get; }
        //private Student _student = new Student();

        IEnumerable<Student> _students = StudentRepository.GetAll();

        public EditVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            Student = new Student();
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }

        public Student GetStudent(int studentId)
        {

            IEnumerable<Student> _students = StudentRepository.GetAll();

            var selectedStudent = _students.First(s => s.StudentId == studentId);

            return selectedStudent;

        }

        public static void Edit(EditVM editVM)
        {

            IEnumerable<Student> _students = StudentRepository.GetAll();

            var selectedStudent = _students.First(s => s.StudentId == editVM.Student.StudentId);

            IEnumerable<Major> _majors = MajorRepository.GetAll();

            Major _major = _majors.First(c => c.MajorId == editVM.Student.Major.MajorId);

            IEnumerable<Course> AllCourses = CourseRepository.GetAll();

            List<Course> _courses = new List<Course>();

            foreach (var x in AllCourses)
            {
                foreach (var y in editVM.SelectedCourseIds)

                    if (x.CourseId == y)
                    {
                        new Course { CourseId = x.CourseId, CourseName = x.CourseName };
                    }
            }

            selectedStudent.FirstName = editVM.Student.FirstName;
            selectedStudent.LastName = editVM.Student.LastName;
            selectedStudent.GPA = editVM.Student.GPA;
            selectedStudent.Major = _major;
            selectedStudent.Courses = _courses;
            selectedStudent.Address.Street1 = editVM.Student.Address.Street1;
            selectedStudent.Address.Street2 = editVM.Student.Address.Street2;
            selectedStudent.Address.City = editVM.Student.Address.City;
            selectedStudent.Address.State = editVM.Student.Address.State;
            selectedStudent.Address.PostalCode = editVM.Student.Address.PostalCode;
            
        }

    }
}