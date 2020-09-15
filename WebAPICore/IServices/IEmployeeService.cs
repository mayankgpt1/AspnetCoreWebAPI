using System.Collections.Generic;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeById(int id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int Id);
    }
}
