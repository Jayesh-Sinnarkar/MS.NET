namespace ModelBinding.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public static Employee GetSingleEmployee(int EmpNo)
        { 
            Employee employee = new Employee();
            return employee;
        }
        public static List<Employee> GetAllEmployees() 
        { 
            List<Employee> list = new List<Employee>(); 
            return list;
        }

        public static void Insert(Employee obj)
        { }

        public static void Update(Employee obj)
        { }

        public static void Delete(int EmpNo)
        { }


    }

}
