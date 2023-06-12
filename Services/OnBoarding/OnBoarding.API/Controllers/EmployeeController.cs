using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        // http:localhost/api/Employees
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeesByPagination(int page = 1, int pageSize = 10)
        {
            var employees = await _employeeService.GetEmployeesByPagination(page, pageSize);

            if (!employees.Any())
            {
                return NotFound(new { error = "No Employees found, please try later" });
            }
            return Ok(employees);
        }
        
        // http:localhost/api/Employees/1
        [HttpGet]
        [Route("{id:int}", Name="GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(new { errorMessage = "No Employee found for this id" });
            }
            return Ok(employee);
        }
        
        // http:localhost/api/Employees
        [HttpPost]
        [Route("", Name = "AddEmployee")]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var employee = await _employeeService.AddEmployee(model); 
            return CreatedAtRoute("GetEmployeeDetails", new { id = employee.Id }, employee);
        }
        
        // http:localhost/api/Employees/1
        [HttpPut]
        [Route("{id:int}", Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateModel model)
        {
            var employee = await _employeeService.UpdateEmployee(id, model);
            if (employee == null)
            {
                return NotFound(new { error = "Employee not found" });
            }
            return Ok(employee);
        }

        // http:localhost/api/Employees/1/terminate
        [HttpPut]
        [Route("{id:int}/terminate")]
        public async Task<IActionResult> TerminateEmployee(int id)
        {
            var employee = await _employeeService.TerminateEmployee(id);
            if (employee == null)
            {
                return NotFound(new { error = "Employee not found" });
            }
            return Ok(employee);
        }
    }
}
