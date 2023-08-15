using EmployeeMngmt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace EmployeeMngmt.Controllers
{
    public class EmployeesController : Controller
    {
        string ConnectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // GET: EmployeesController
        //Adding Select all Employees to verify if Employee will be added or deleted
        public ActionResult Index()
        {

            List<Employee> list = Employee.SelectAllEmployees();
            return View(list);

        }

        

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            
                    return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConnectionStr;
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Employees values(@Id,@Name,@City,@Address)";
                        cmd.Parameters.AddWithValue("@Id", emp.Id);
                        cmd.Parameters.AddWithValue("@Name", emp.Name);
                        cmd.Parameters.AddWithValue("@City", emp.City);
                        cmd.Parameters.AddWithValue("@Address", emp.Address);

                        try
                        {
                            int rowCount = cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            ViewBag.ErrorMessage = "An error occurred while adding employee information." + ex.Message;
                            return View();
                        }
                    }
                        
                }

                Employee.AddEmployee(emp);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee e = Employee.GetEmpById(id);
            return View(e);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee emp)
        {
            try
            {
                Employee.DeleteEmployee(emp.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                    ViewBag.ErrorMessage = "An error occurred while retrieving employee information." + ex.Message; 
                    return View(Index);
                
            }
                 
        }

       
    }
}
