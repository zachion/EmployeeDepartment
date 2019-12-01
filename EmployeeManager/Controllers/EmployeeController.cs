using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public IActionResult Index(string searchString)
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeService.GetAllEmployees().ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                lstEmployee = employeeService.GetSearchResult(searchString).ToList();
            }
            return View(lstEmployee);
        }

        public ActionResult AddEditEmployees(int itemId)
        {
            Employee model = new Employee();
            if (itemId > 0)
            {
                model = employeeService.GetEmployeeData(itemId);
            }
            return PartialView("_employeeForm", model);
        }

        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                if (newEmployee.ItemId > 0)
                {
                    employeeService.UpdateEmployee(newEmployee);
                }
                else
                {
                    employeeService.AddEmployee(newEmployee);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

      
    }
}