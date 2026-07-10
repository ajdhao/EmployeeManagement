using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;

namespace EmployeeManagement
{
    public static class DbConstant
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
            }
        }
        public static string sp_GetAllEmployee = "usp_GetAllEmployee";
        public static string sp_CreateEmployee = "usp_CreateEmployee";
        public static string sp_EditEmployee = "usp_EditEmployee";
        public static string sp_DeleteEmployee = "usp_DeleteEmployee";
    }
}