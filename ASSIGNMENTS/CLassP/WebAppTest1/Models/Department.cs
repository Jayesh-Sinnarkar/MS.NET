using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAppTest1.Models
{
    public class Department
    {
        public int DeptNo { get; set; }

        public string DeptName { get; set; }

        public Department(int DeptNo, string DeptName) { 
        
            this.DeptNo = DeptNo;
            this.DeptName = DeptName;
        }

        public static List<Department> GetAllDepartments()
        {
            List<Department> deptList = new List<Department>();
            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using(SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Departments";
                    try
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Department d = new Department(
                                DeptNo: dr.GetInt32("DeptNo"),
                                DeptName: dr.GetString("DeptName")
                                );
                            deptList.Add(d);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    return deptList;
                }
            }

        }
    }
}
