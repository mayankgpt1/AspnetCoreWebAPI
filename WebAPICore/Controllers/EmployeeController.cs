using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.IServices;
using WebAPICore.Models;
namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employee)
        {
            employeeService = employee;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Employee/GetEmployee")]
        public IEnumerable<Employee> GetEmployee()
        {
            return employeeService.GetEmployee();
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/Employee/AddEmployee")]
        public bool AddEmployee(Employee employee)
        {
            return employeeService.AddEmployee(employee);
        }
        [HttpPut]
        [Route("[action]")]
        [Route("api/Employee/EditEmployee")]
        public bool EditEmployee(Employee employee)
        {
            return employeeService.UpdateEmployee(employee);
        }
        [HttpDelete]
        [Route("[action]")]
        [Route("api/Employee/DeleteEmployee")]
        public bool DeleteEmployee(int Id)
        {
            return employeeService.DeleteEmployee(Id);
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Employee/GetEmployeeId")]
        public Employee GetEmployeeId(int id)
        {
            return employeeService.GetEmployeeById(id);
        }
    }
}