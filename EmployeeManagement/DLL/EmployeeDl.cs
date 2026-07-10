using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;

namespace EmployeeManagement.DLL
{
    public class EmployeeDl
    {
        List<Employee> employees = new List<Employee>();
        public List<Employee> GetAllEmployee()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.sp_GetAllEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        {
                            employee.Id = (int)reader["Id"];
                            employee.Name = reader["Name"].ToString();
                            employee.Email = reader["Email"].ToString();
                            employee.Password = reader["Password"].ToString();
                        }
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return employees;
        }

        public bool CreateEmployee(Employee employee)
        {
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.sp_CreateEmployee, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                SqlParameter CreateStatus = new SqlParameter()
                {
                    ParameterName = "@CreateStatus",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(CreateStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)CreateStatus.Value;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                }
            }
        }

        public bool EditEmployee(Employee employee)
        {
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.sp_EditEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                SqlParameter EditStatus = new SqlParameter()
                {
                    ParameterName = "@EditStatus",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(EditStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)EditStatus.Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public bool DeleteEmployee(int? Id)
        {
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(DbConstant.ConnectionString);
                SqlCommand cmd = new SqlCommand(DbConstant.sp_DeleteEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",Id);
              
                SqlParameter DeleteStatus = new SqlParameter()
                {
                    ParameterName = "@Deletetatus",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(DeleteStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)DeleteStatus.Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}