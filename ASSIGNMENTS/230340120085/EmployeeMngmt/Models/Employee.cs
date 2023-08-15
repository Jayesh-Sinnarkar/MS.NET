using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EmployeeMngmt.Models
{
    public class Employee
    {
        //------//ID is primary Key   --------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }



        //------//Name should be less than 90 characters and is Required Field   --------------------------------------------------------------------------
        [Required(ErrorMessage = "Name Is Required Field")]
        [StringLength(90, ErrorMessage = "Name Should be Less Than 90 Characters.")]
        public string Name { get; set; }



        //------//City should be less than 20 characters and is Required Field   --------------------------------------------------------------------------
        [Required(ErrorMessage = "City Is Required Field")]
        [StringLength(20, ErrorMessage = "City Should be Less Than 20 Characters.")]
        public string City { get; set; }



        //------//Address should be less than 400 characters and is Required Field   --------------------------------------------------------------------------
        [Required(ErrorMessage = "Address Is Required Field")]
        [StringLength(400, ErrorMessage = "Address Should be Less Than 400 Characters.")]
        public string Address { get; set; }


        //------// Method To: Retrive Employee with perticular ID   --------------------------------------------------------------------------
        public static Employee GetEmpById(int empNo)
        {
            Employee emp = null;
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Employees where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", empNo);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            emp = new Employee()
                            {
                                Id = rd.GetInt32("Id"),
                                Name = rd.GetString("Name"),
                                City = rd.GetString("City"),
                                Address = rd.GetString("Address")
                            };
                        }

                    }
                }
            }

            return emp;
        }



        //------//Method to Delete Employee with perticular ID--------------------------------------------------------------------------
        public static string DeleteEmployee(int id)
        {
            string message = null;
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Delete from Employees where Id=@EmpNo";
                    cmd.Parameters.AddWithValue("@EmpNo", id);
                    try
                    {
                        int rowCount = cmd.ExecuteNonQuery();
                        message = rowCount + " records are deleted.";
                    }
                    catch (Exception ex)
                    {
                        message = "Could Nor Delete Records: " + ex.Message;

                    }
                }

            }


            return message;
        }

        //------//Method to Delete Employee with perticular ID--------------------------------------------------------------------------
        public static List<Employee> SelectAllEmployees()
        {
            Employee emp = null;
            List<Employee> list = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    emp = new Employee();
                    emp.Id = (int)rd["Id"];
                    emp.Name = (string)rd["Name"];
                    emp.Address = (string)rd["Address"];
                    emp.City = (string)rd["City"];
                    list.Add(emp);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return list;
        }



//------//Method to Insert Employee with perticular ID--------------------------------------------------------------------------
        public static string AddEmployee(Employee emp)
        {
            string message = null;
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
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
                        message = emp.ToString + " Added to record";
                    }
                    catch (Exception ex)
                    {
                        message = " Could not add employee: " + ex.Message;
                        throw ex;
                    }

                    return message;

                }


            }

        }

    }
}


