using EmployeeManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class EmployeesDataAcessLayer : IEmployeeService
    {
        private EmployeeManagerDBContext db;

        public EmployeesDataAcessLayer(EmployeeManagerDBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employee.ToList();
            }
            catch
            {
                throw;
            }
        }

        // To filter out the records based on the search string 
        public IEnumerable<Employee> GetSearchResult(string searchString)
        {
            List<Employee> exp = new List<Employee>();
            try
            {
                exp = GetAllEmployees().ToList();
                return exp.Where(x => x.EmployeeFirstName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        //To Add new Employee record       
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employee.Add(employee);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee  
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular employee  
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = db.Employee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.Employee.Find(id);
                db.Employee.Remove(emp);
                db.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

      
    }
}
