using Microsoft.Data.SqlClient;
using System.Data;
namespace DatabaseCode
{
    internal class Program
    {
        static void Main()
        {
            //Connect();
            //Insert1();

            Employee employee = new Employee { EmpNo=7,Name="Alfred D'Mello",Basic=12000,DeptNo=30};
            //Insert2(employee);
            //Insert3(employee);
            //Insert4(employee);
            //ReturnASingleValue();
            //DataReader1();
            //DataReader2();
            //MARS();
            //CallFuncReturningSqlDataReader();
            Transactions();
        }
        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;User Id=sa;Password=sa";
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            Console.WriteLine("open");
            cn.Close();
        }
        static void Insert1()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees values(4,'Nilesh', 20000, 10)";
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Insert2(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}', {obj.Basic}, {obj.DeptNo})";
            Console.WriteLine(cmd.CommandText );
            Console.ReadLine();
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Insert3(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into Employees values(@EmpNo,@Name, @Basic,@DeptNo)";

            cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Basic", obj.Basic);
            cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);


            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Insert4(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Basic", obj.Basic);
            cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);


            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void ReturnASingleValue()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name from Employees where EmpNo=1";
            //cmd.CommandText = "select count(*) from Employees";
            //cmd.CommandText = "select * from Employees";
            try
            {
                object obj = cmd.ExecuteScalar();
                Console.WriteLine(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void DataReader1()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr["EmpNo"]);
                    int EmpNo;
                    EmpNo = (int)dr[0];
                    EmpNo = (int)dr["EmpNo"];
                    EmpNo = dr.GetInt32(0);
                    EmpNo = dr.GetInt32("EmpNo");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static Employee GetSingleEmployee(int EmpNo)
        {
            Employee obj = new Employee();

            return obj;
        }
        static List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps = new List<Employee>();
            return lstEmps;
        }

        static void DataReader2()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            cn.Open();
            //SqlCommand cmd = cn.CreateCommand();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees;select * from Departments";
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr["Name"]);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    Console.WriteLine(dr["DeptName"]);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void MARS()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                Console.WriteLine((drDepts["DeptName"]));

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    Console.WriteLine(("    " + drEmps["Name"]));
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        static void CallFuncReturningSqlDataReader()
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[1]);
            }
            dr.Close();
            //Console.WriteLine(cn.State);
        }
        //static SqlConnection cn;
        static SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            //cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Employees ";
            //SqlDataReader dr = cmdInsert.ExecuteReader();
            SqlDataReader dr = cmdInsert.ExecuteReader(CommandBehavior.CloseConnection);
            //cn.Close();
            return dr;
        }
        static void Connect2()
        {
            //SqlConnection cn = new SqlConnection();
            ////cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;User Id=sa;Password=sa";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
            //cn.Open();
            //Console.WriteLine("open");
            //cn.Close();
            using (SqlConnection cn = new SqlConnection())
            {
                //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;User Id=sa;Password=sa";
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJune23;Integrated Security=true";
                cn.Open();
                Console.WriteLine("open");
            }
            
        }
        static void Transactions()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.Transaction = t;

            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(10, 'Shweta', 12345, 30)";

            SqlCommand cmdInsert2 = new SqlCommand();
            cmdInsert2.Connection = cn;
            cmdInsert2.Transaction = t;

            cmdInsert2.CommandType = System.Data.CommandType.Text;
            cmdInsert2.CommandText = "insert into Employees values(20, 'Shweta', 12345, 30)";
            try
            {
                cmdInsert.ExecuteNonQuery();
                cmdInsert2.ExecuteNonQuery();
                t.Commit();
                Console.WriteLine("no errors- commit");
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine("Rollback");
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}