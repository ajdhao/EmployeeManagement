using EmployeeManagement.BLL;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //test commit 
        //employee-api-optimization
        public ActionResult Index()
        {
            EmployeeBl bl = new EmployeeBl();
          List<Employee> employee = bl.GetAllEmployee();
            return View(employee);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeBl bl = new EmployeeBl();
            if (ModelState.IsValid)
            {
                if (bl.CreateEmployee(employee))
                {
                    return RedirectToAction("Index");
                }
            }           
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            EmployeeBl bl = new EmployeeBl();
           Employee employee = bl.GetAllEmployee().Find(e => e.Id == Id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            EmployeeBl bl = new EmployeeBl();
            if (ModelState.IsValid)
            {
                if (bl.EditEmployee(employee))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            EmployeeBl bl = new EmployeeBl();
            Employee employee = bl.GetAllEmployee().Find(e => e.Id == Id);
            return View(employee);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int? Id)
        {
            EmployeeBl bl = new EmployeeBl();
            if (ModelState.IsValid)
            {
                if (bl.DeleteEmployee(Id))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Details(int? Id)
        {
            EmployeeBl bl = new EmployeeBl();
            Employee employee = bl.GetAllEmployee().Find(e => e.Id == Id);
            return View(employee);
        }
    }
}