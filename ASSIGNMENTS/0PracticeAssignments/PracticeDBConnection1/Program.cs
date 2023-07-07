using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Data;

namespace PracticeDBConnection1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection();
            //InsertEmployee(new Employee("A1",15000,1));
            //selectEmployee(10);
            /* Console.Write("\nEnter Id:");
             int id = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Enter new Baic: ");
             decimal basic = Convert.ToDecimal(Console.ReadLine());
             UpdateEmployee(id, basic);*/

            selectAllEmps();

        }

        public static void Connection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsJune23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
            connection.Open();
            Console.WriteLine("Open");
            connection.Close();

        }

        public static void InsertEmployee(Employee e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsJune23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
            connection.Open();
            Console.WriteLine("Open");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = $"insert into Employees values({e.EmpNo},'{e.Name}',{e.Basic},{e.DeptNo})";
            Console.WriteLine(command.CommandText);
            Console.ReadLine();
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Inserted");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void selectEmployee(int EmoNo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
            
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsJune23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
            cn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = cn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SelectEmployee";
            command.Parameters.AddWithValue("@EmoNo", 10);
            //Console.WriteLine(command.CommandText);
           // Console.ReadLine();
            
                SqlDataReader rd = command.ExecuteReader();
                while(rd.Read())
                {
                    int empNo = rd.GetInt32("EmoNo");
                    string name = rd.GetString("Name");
                    decimal basic = rd.GetDecimal("Basic");
                    int deptNo = rd.GetInt32("DeptNo");
                    Console.WriteLine("EmpNo :"+empNo+" Name: "+name+" Basic: "+basic+" DeptNo: "+deptNo);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
           
        }

        //UPDATE EMPLOYEE
        public static void UpdateEmployee(int empNo, decimal basic)
        {
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsJune23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
                cn.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = cn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update Employees set Basic=@Basic where EmoNo=@EmpNo";
                    command.Parameters.AddWithValue("@Basic", basic);
                    command.Parameters.AddWithValue("@EmpNo", empNo);
                    try
                    {
                       int rowsAffected =  command.ExecuteNonQuery();
                       Console.WriteLine("Rows Affected: " + rowsAffected);
                        selectEmployee(empNo);
                    }catch(Exception ex) { Console.WriteLine(ex.Message); }
                   /* using(SqlDataReader rd = command.ExecuteReader())
                    {
                        while(rd.Read())
                        {
                            Employee emp = new Employee(
                                name: rd.GetString("Name"),
                                basic: rd.GetDecimal("Basic") ) ;
                            Console.WriteLine(emp.Name + emp.Basic);
                        }
                    }*/
                }
            
            
            }

        }

        public static void selectAllEmps()
        {
            List<Employee> empList = null;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = ActsJune23; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
                cn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from EMployees";
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        empList = new List<Employee>();
                        while (rd.Read())
                        {
                            empList.Add(new Employee(empNo: rd.GetInt32("EmoNo"), name: rd.GetString("Name"), basic: rd.GetDecimal("Basic"), deptNo: rd.GetInt32("DeptNo")));
                        }

                        foreach (Employee e in empList)
                        {
                            Console.WriteLine(e);
                        }
                    }

                }


            }

        
        }


    }



    public class Employee
    {
        private int count = 15;
        private int empNo = 0;
        public int EmpNo { get { return empNo; } set { empNo = value; } }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public Employee(string name = "default", decimal basic = 0, int deptNo = 0)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            ++count;
            this.EmpNo = count;
        }

        public Employee(int empNo=0, string name = "default", decimal basic = 0, int deptNo = 0)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            this.EmpNo = empNo;
        }

        public override string ToString()
        {
            return "[ EmpNo: "+EmpNo+" Name: "+Name+" Basic: "+Basic+" DeptNo: "+DeptNo+" ]";
        }

    }
}