using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Department> GetSearchResult(string searchString);
        void AddDepartment(Department department);
        int UpdateDepartment(Department department);
        Department GetDepartmentData(int id);
        void DeleteDepartment(int id);
    }
}
