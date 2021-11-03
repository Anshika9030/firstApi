using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Respository
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee CreateEmployee(Employee emp);
        Employee GetEmployeeById(int id);
    }
}
