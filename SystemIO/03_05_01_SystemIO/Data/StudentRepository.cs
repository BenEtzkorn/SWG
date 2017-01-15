using _03_05_01_SystemIO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05_01_SystemIO.Data
{
    public class StudentRepository
    {
        private string _filePath;

        public StudentRepository(string filePath)
        {
            _filePath = filePath;

            //create and populate column names if file does not yet exist
            if (!File.Exists(_filePath))
            {
                File.Create(@".\Students.txt");

                using (StreamWriter writer = new StreamWriter(_filePath))
                {

                    writer.WriteLine("FirstName,LastName,Major,GPA,CreditHours");

                }

            }

        }

        // list, add, edit, delete
        public ListStudentResponse List()
        {

            ListStudentResponse response = new Models.ListStudentResponse();

            response.Success = true;

            response.Students = new List<Student>();

            try
            {

                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Student newStudent = new Student();

                        string[] columns = line.Split(',');

                        newStudent.FirstName = columns[0];
                        newStudent.LastName = columns[1];
                        newStudent.Major = columns[2];
                        newStudent.GPA = decimal.Parse(columns[3]);
                        newStudent.CreditHours = int.Parse(columns[4]);

                        response.Students.Add(newStudent);
                    }
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }


            return response;
        }

        public void Add(Student student)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCsvForStudent(student);

                sw.WriteLine(line);
            }
        }

        public void Edit(Student student, int index)
        {
            var response = List();

            response.Students[index] = student;

            CreateStudentFile(response.Students);
        }

        public void Delete(int index)
        {
            var response = List();

            response.Students.RemoveAt(index);

            CreateStudentFile(response.Students);
        }

        private string CreateCsvForStudent(Student student)
        {
            return string.Format("{0},{1},{2},{3},{4}", student.FirstName,
                    student.LastName, student.Major, student.GPA.ToString(),student.CreditHours);
        }

        private void CreateStudentFile(List<Student> students)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("FirstName,LastName,Major,GPA,CreditHours");
                foreach(var student in students)
                {
                    sr.WriteLine(CreateCsvForStudent(student));
                }
            }
        }
    }
}
