using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetSearchResult(string searchString);
        void AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        Employee GetEmployeeData(int id);
        void DeleteEmployee(int id);
    
    }
}
