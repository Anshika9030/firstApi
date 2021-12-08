using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Respository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        public IEmployee Employees { get; }
        public EmployeesController(IEmployee employee)
        {
            Employees = employee;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult Get()
        {
            var result = Employees.GetEmployees();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Post(Employee em)
        {
            var result= Employees.CreateEmployee(em);
            if (result != null)
            {
                return Ok("Employee Created");
            }
            else
            {
                return Ok("not created");
            }
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public IActionResult Get(int id)
        {
            var result = Employees.GetEmployeeById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }



    }
}
