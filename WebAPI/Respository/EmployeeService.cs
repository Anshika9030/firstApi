using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Respository
{
    public class EmployeeService : IEmployee
    {
        private List<Employee> employees;
        public EmployeeService()
        {
            employees = new List<Employee>()
            {
                new Employee(){Id=1,Name="ajay",Gender="male"},
                new Employee(){Id=2,Name="rajiv",Gender="male"},
                new Employee(){Id=3,Name="mohit",Gender="male"},

            };
        }
        public Employee CreateEmployee(Employee emp)
        {
            employees.Add(emp);
            return emp;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.SingleOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees.ToList();
        }
    }
}
