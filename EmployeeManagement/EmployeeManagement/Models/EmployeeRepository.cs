using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees;

        static EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee { EmployeeId=1, FirstName="Jim", LastName="Jones", Phone="612-555-1212", DepartmentId=1 },
                new Employee { EmployeeId=2, FirstName="Joseph", LastName="Mambro", Phone="651-555-1212", DepartmentId=2 },
                new Employee { EmployeeId=3, FirstName="Mother", LastName="Theresa", Phone="763-555-1212", DepartmentId=3 },
            };
        }

        public static void Add(Employee employee)
        {
            if(_employees.Any())
            {
                employee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;
            }
            else
            {
                employee.EmployeeId = 1;
            }

            _employees.Add(employee);
        }
        public static void Edit(Employee employee)
        {
            //Eric tried this method first but it didn't work.  We must delete then add, which he added below
            //Employee found = _employees.First(e => employee.EmployeeId == e.EmployeeId);
            //found = employee;
  
            _employees.RemoveAll(e => e.EmployeeId == employee.EmployeeId);
            _employees.Add(employee);
        }

        public static void Delete(int employeeId)
        {
            _employees.RemoveAll(e => e.EmployeeId == employeeId);
        }

        public static Employee Get(int employeeId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public static List<Employee> GetAll()
        {
            return _employees;
        }
    }
}