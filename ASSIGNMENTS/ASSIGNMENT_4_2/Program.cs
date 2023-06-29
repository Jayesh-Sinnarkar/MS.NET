/*2.Create an array of Employee class objects
        Accept details for all Employees
        Display the Employee with highest Salary
        Accept EmpNo to be searched. Display all details for that employee
*/

namespace ASSIGNMENT_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter No of EMployees you want to store: ");
            int empCount = Convert.ToInt32(Console.ReadLine());

            Employee[] empRecord = new Employee[empCount];


            //Read Employee details and stored in array
            for (int i = 0; i < empRecord.Length; i++)
            {
                Console.WriteLine($"Enter Detils of employee {i+1}");
                empRecord[i] = new Employee();
                Console.Write("enter name: ");
                empRecord[i].Name = Console.ReadLine();

                Console.Write("Enter Department Number: ");
                empRecord[i].DeptNo = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter Salary: ");
                empRecord[i].Basic = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();

            }

            //Display Employee with highest salary
            decimal highestSal = 0;
            int pos = 0;
            foreach (Employee emp in empRecord)
            {
                if (emp.Basic > highestSal)
                {
                    highestSal = emp.Basic;
                    pos = Array.IndexOf(empRecord, emp);
                }
                
            }
            Console.WriteLine("Details of employee with highest salary:");
            Console.WriteLine(empRecord[pos]);

            // Accept EmpNo to be searched. Display all details for that employee
            Console.WriteLine();
            Console.Write("Enter employee id:");
            int index=0, id = Convert.ToInt32(Console.ReadLine());

           for(int i=0; i<empRecord.Length;i++)
            {
                if (empRecord[i].EmpNo == id)
                    index = i;
            }
            Console.WriteLine(empRecord[index]);


        }
    }

    public class Employee
    {

        public Employee()
        {
            EmpCount++;
            EmpNo = EmpCount;
        }

        private string? name;
        public string? Name
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    System.Console.WriteLine("Invalid Name Input");
            }

            get { return name; }
        }

        private static int empCount = 0;
        public static int EmpCount { set { empCount = value; } get { return empCount; } }


        private int empNo;
        public int EmpNo
        {
            set
            {
                if (value != 0)
                    empNo = value;
                else System.Console.WriteLine("Invalid EmpId");
            }
            get { return empNo; }
        }

        private decimal basic;
        public decimal Basic
        {
            set
            {
                if (100000 >= value && value >= 1000)
                    basic = value;
            }
            get { return basic; }
        }

        private short deptNo;
        public short DeptNo
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else System.Console.WriteLine("Invalid department number!");
            }
            get { return deptNo; }
        }



        public override string ToString()
        {
            return "Employee [ Name: " + Name + ", EmpId:" + EmpNo + ",  DeptNo: " + DeptNo + ", Basic:" + Basic + " ]";
        }

    }
}
