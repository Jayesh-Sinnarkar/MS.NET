using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentMgnt.Models;
using System.Data;

namespace StudentMgnt.Controllers
{
    public class Departments : Controller
    {
        string CnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentMgnt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // GET: Departments
        public ActionResult Index()
        {
            List<Department> dlist = new List<Department>();
            try
            {
                using (SqlConnection cn = new SqlConnection(CnStr))
                {
                    cn.Open();
                    string query = "select * from departments";
                    SqlCommand sqlCommand = new SqlCommand(query, cn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Department d = new Department
                        {
                            DeptNo = (int)reader["deptno"],
                            Dname = (string)reader["dname"]
                        };
                        dlist.Add(d);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving department information.";

            }
            return View(dlist);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            List<Student> slist = new List<Student>();
            Department d = new Department();
            try
            {
                string query = "SELECT * FROM departments WHERE deptno=@id";
                using(SqlConnection cn = new SqlConnection(CnStr))
                {
                    cn.Open();
                    SqlCommand cmd1 = new SqlCommand(query, cn);
                    cmd1.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        d.DeptNo = (int)reader["deptno"];
                        d.Dname = (string)reader["dname"];
                    }            
                    reader.Close();
                    query = "SELECT rollNo, fname, lname FROM students where deptno = @id";
                    SqlCommand cmd2 = new SqlCommand(query, cn);
                    cmd2.Parameters.AddWithValue("id", id);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while(reader2.Read())
                    {
                        Student s = new Student
                        {
                            RollNo = (int)reader2["rollNo"],
                            Fname = (string)reader2["fname"],
                            Lname = (string)reader2["lname"],
                        };
                        slist.Add(s);
                    }
                    reader2.Close ();
                    d.Students = slist;
                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving department information.";
            }


            return View(d);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department d)
        {
            string query = "INSERT INTO departments values(@deptno,@dname)";
            try
            {
                using(SqlConnection conn = new SqlConnection(CnStr))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@deptno", d.DeptNo);
                    cmd.Parameters.AddWithValue("@dname", d.Dname);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return View();
                    }

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
