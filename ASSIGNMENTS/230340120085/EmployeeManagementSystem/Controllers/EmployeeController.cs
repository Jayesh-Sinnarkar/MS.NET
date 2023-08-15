using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;


namespace EmployeeManagementSystem.Controllers
{

    public class EmployeeController : Controller
    {
        

        // Action for viewing all employee information
        public ActionResult index()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeMgnt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, City, Address FROM Employee";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            City = (string)reader["City"],
                            Address = (string)reader["Address"]
                        };

                        employees.Add(employee);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving employee information.";
                
            }

            return View(employees);
        }

        // Action for editing employee information
        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeMgnt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, City, Address FROM Employee WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employee.Id = (int)reader["Id"];
                        employee.Name = (string)reader["Name"];
                        employee.City = (string)reader["City"];
                        employee.Address = (string)reader["Address"];
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving employee information."+ex.Message;
                
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeMgnt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    connection.Open();
                    string query = "UPDATE Employee SET Name = @Name, City = @City, Address = @Address WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@City", employee.City);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while updating the employee."+ex.Message;
                
            }

            return RedirectToAction("Index");
        }

        
    }


}
