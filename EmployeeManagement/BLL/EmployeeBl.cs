using EmployeeManagement.DLL;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.BLL
{
    public class EmployeeBl
    {
        EmployeeDl dl = null;
        public EmployeeBl()
        {
            dl = new EmployeeDl();
        }
        public List<Employee> GetAllEmployee()
        {
            return dl.GetAllEmployee();
        }
        public bool CreateEmployee(Employee employee)
        {
            return dl.CreateEmployee(employee);
        }
        public bool EditEmployee(Employee employee)
        {
            return dl.EditEmployee(employee);
        }
        public bool DeleteEmployee(int? Id)
        {
            return dl.DeleteEmployee(Id);
        }
    }
}