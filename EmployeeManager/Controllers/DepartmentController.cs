using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        public IActionResult Index(string searchString)
        {
            List<Department> lstDepartment = new List<Department>();
            lstDepartment = departmentService.GetAllDepartments().ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                lstDepartment = departmentService.GetSearchResult(searchString).ToList();
            }
            return View(lstDepartment);
        }

        public ActionResult AddEditDepartments(int itemId)
        {
            Department model = new Department();
            if (itemId > 0)
            {
                model = departmentService.GetDepartmentData(itemId);
            }
            return PartialView("_departmentForm", model);
        }

        [HttpPost]
        public ActionResult Create(Department newDepartment)
        {
            if (ModelState.IsValid)
            {
                if (newDepartment.DepartmentId > 0)
                {
                    departmentService.UpdateDepartment(newDepartment);
                }
                else
                {
                    departmentService.AddDepartment(newDepartment);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentSummary()
        {
            return PartialView("_departmentReport");
        }
               
    }
}