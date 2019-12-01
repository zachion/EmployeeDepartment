using EmployeeManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class DepartmentsDataAcessLayer : IDepartmentService
    {
        private EmployeeManagerDBContext db;

        public DepartmentsDataAcessLayer(EmployeeManagerDBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                return db.Department.ToList();
            }
            catch
            {
                throw;
            }
        }

        // To filter out the records based on the search string 
        public IEnumerable<Department> GetSearchResult(string searchString)
        {
            List<Department> exp = new List<Department>();
            try
            {
                exp = GetAllDepartments().ToList();
                return exp.Where(x => x.DepartmentName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        //To Add new Department record       
        public void AddDepartment(Department department)
        {
            try
            {
                db.Department.Add(department);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar department  
        public int UpdateDepartment(Department department)
        {
            try
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular department  
        public Department GetDepartmentData(int id)
        {
            try
            {
                Department department = db.Department.Find(id);
                return department;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular department  
        public void DeleteDepartment(int id)
        {
            try
            {
                Department emp = db.Department.Find(id);
                db.Department.Remove(emp);
                db.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

     
    }
}
