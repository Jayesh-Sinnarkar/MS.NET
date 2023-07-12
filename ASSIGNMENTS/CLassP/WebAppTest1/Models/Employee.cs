using NuGet.Protocol.Plugins;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAppTest1.Models
{
    public class Employee
    {
        private int count = 0;
        
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        //CONSTRUCTORS
        public Employee()
        {
            ++count;
            this.EmpNo = count;
        }
        public Employee(string name = "default", decimal basic = 0, int deptNo = 0)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            ++count;
            this.EmpNo = count;
        }

        public Employee(int empNo = 0, string name = "default", decimal basic = 0, int deptNo = 0)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            this.EmpNo = empNo;
        }
        //METHODS
        public override string ToString()
        {
            return "[ EmpNo: " + EmpNo + " Name: " + Name + " Basic: " + Basic + " DeptNo: " + DeptNo + " ]";
        }


        public static List<Employee> SelectAllEmployees()
        {
            List<Employee> empList = null;

            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using(SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Employees";
                    try
                    {
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            empList = new List<Employee>();
                            while (rd.Read())
                            {
                                empList.Add(new Employee(empNo: rd.GetInt32("EmoNo"),
                                                         name: rd.GetString("Name"),
                                                         basic: rd.GetDecimal("Basic"),
                                                         deptNo: rd.GetInt32("DeptNo")));


                            }
                        }                    
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }


                }
            
            }

            return empList;
        }

        public static Employee GetEmpById(int empNo)
        {
            Employee emp = null;
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using( SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Employees where EmoNo=@EmpNo";
                    cmd.Parameters.AddWithValue("@EmpNo", empNo);
                    using(SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if(rd.Read()) { 
                        emp = new Employee(empNo: rd.GetInt32("EmoNo"), 
                                           name: rd.GetString("Name"), 
                                           basic: rd.GetDecimal("Basic"),
                                           deptNo: rd.GetInt32("DeptNo"));
                        }
                    }
                }
            
            
            }

            return emp;
        }

        public static string UpdateEmployee(Employee emp)
        {
            string message = null;

            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using(SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Employees set Name=@Name, Basic=@Basic, DeptNo=@DeptNo where EmoNo=@EmpNo";
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                    cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                    cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                    try
                    {
                        int rowCount = cmd.ExecuteNonQuery();
                        message = rowCount + " rows successfully updated.";

                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        message = "Cound not update Employee "+ emp.ToString;
                    }

                }
            }
            return message;
        }

        public static string DeleteEmployee(int id)
        {
            string message = null;
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using(SqlCommand cmd =cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Delete from Employees where EmoNo=@EmpNo";
                    cmd.Parameters.AddWithValue("@EmpNo", id);
                    try
                    {
                        int rowCount = cmd.ExecuteNonQuery();
                        message = rowCount + " records are deleted.";
                    }catch(Exception ex)
                    {
                        message = "Could Nor Delete Records: "+ex.Message;
                    }
                }

            }


            return message;
        }

        public static string AddEmployee(Employee emp)
        {
            string message = null;
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using(SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                    cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                    cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                    try
                    {
                        int rowCount = cmd.ExecuteNonQuery();
                        message = emp.ToString + " Added to record";
                    }catch(Exception ex)
                    {
                        message = " Could not add employee: "+ex.Message;
                    }

                    return message;

                }
            }
        }
    }
}
