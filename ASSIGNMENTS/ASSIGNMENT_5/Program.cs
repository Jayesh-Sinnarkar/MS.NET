/*1.Declare a dictionary based collection of Employee class objects


Accept details for Employees  in a loop. Stop accepting based on user input (yes/no)'
Display the Employee with highest Salary
Accept EmpNo to be searched. Display all details for that employee.
Display details for the Nth Employee where N is a number accepted from the user.


2. Create an array of Employee objects. Convert it to a List<Employee>.  Display all the Employees in the list.

3. Create a List<Employee>. Convert it to an array. Display all the array elements.*/

namespace ASSIGNMENT_5
{
    internal class Program
    {
        static void Main()
        {
            bool exit=false;
            while(!exit)
            {
                try
                {
                    Console.WriteLine("*****MENU*****\n"
                                     +"1. Create New Employee Record.\n"
                                     +"2. Display Employee With Highest Salary.\n"
                                     +"3. Display List of All Employees.\n"
                                     +"4. Display Array of All Employees.\n"
                                     +"0. Exit.");
                    Console.Write("Enter your choice:");
                    int ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1://1. Create New Employee Record.
                            Console.Write("Enter No of Employees to register: ");
                            int empCount = Convert.ToInt32(Console.ReadLine());
                            //Dictionary<int,Employee> emps = new Dictionary<int,Employee>();
                            for(int i = 0; i<empCount; i++)
                            {
                                Console.WriteLine($"\nEnter Employee {i+1} Details.");
                                Console.Write("Enter Employee Name:");
                                string name = Console.ReadLine();
                                Console.Write("Enter Employee Department No:");
                                short deptNo= Convert.ToInt16(Console.ReadLine());
                                Console.Write("Enter Basic Salary:");
                                decimal basic = Convert.ToDecimal(Console.ReadLine());
                                //Calling static function to add emp to record.
                                Employee.AddEmpToRecord(name, deptNo, basic);
                                Console.WriteLine();
                            }
                            Employee.DisplayEmpRecord();
                            break; 

                        case 2://2. Display Employee With Highest Salary.
                            Console.WriteLine("Employee With Highest Salary: ");
                            Console.WriteLine(Employee.FindEmpWithHighestSalary());
                            Console.WriteLine();    
                            break;

                        case 3://3. Display List of All Employees.
                            Console.WriteLine("List of employees: ");
                            List<Employee> empList = Employee.ConvertArrayToList();
                            List<Employee>.Enumerator e = empList.GetEnumerator();
                            while(e.MoveNext())
                            {
                                Console.WriteLine(e.Current);
                            }
                            break;

                        case 4://4. Display Array of All Employees.
                            Employee[] empArr = Employee.GetEmploeeArray();
                            Console.WriteLine("Array Of Employees:");
                            foreach (Employee emp in empArr)
                            {
                                Console.WriteLine(emp);
                            }
                            break;

                        case 0:
                                exit = true;
                                Console.WriteLine("Thank you...");
                            break;

                        default:
                            throw new Exception("Invalid Input.");
                            
                    }

                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public class Employee
        {

            /*public Employee()
            {
                EmpCount++;
                EmpNo = EmpCount;
            }*/


            public Employee(String name = "", short deptNo = 0, decimal basic=0)
            {
                EmpCount++;
                EmpNo = EmpCount;
                Name= name;
                DeptNo = deptNo;
                Basic = basic;
                
            }

            private string? name;
            public string? Name
            {
                set
                {
                    if (!string.IsNullOrEmpty(value))
                        name = value;
                    else
                        throw new Exception("Invalid Name");
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
                    else throw new Exception("Invalid EmpNo");
                }
                get { return empNo; }
            }

            private decimal basic;
            public decimal Basic
            {
                set
                {
                    if (500000 >= value && value >= 1000)
                        basic = value;
                    else throw new Exception("Invalid Base Salary");
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
                    else throw new Exception("Invalid department number!");
                }
                get { return deptNo; }
            }

            //Employee Disctionary
            private static Dictionary<int, Employee> emps =  new Dictionary<int, Employee>();




            //Methods

            //Add Employees to Dictionary
            public static void AddEmpToRecord(string name, short deptNo, decimal basic)
            {
                Employee e = new Employee(name, deptNo, basic);
                emps.Add(e.EmpNo,e);
            }

            public static void DisplayEmpRecord()
            {
                int empCount = emps.Count;
                
                Dictionary<int,Employee>.Enumerator e = emps.GetEnumerator();
                while (e.MoveNext())
                {
                    Console.WriteLine(e.Current);
                }                
            }

            public static Employee? FindEmpWithHighestSalary()
            {
                Dictionary<int, Employee>.Enumerator e = emps.GetEnumerator();

                decimal highestSal = 0;
                int empId = 0;
                while(e.MoveNext())
                {
                    if(e.Current.Value.Basic > highestSal)
                    {
                        highestSal = e.Current.Value.Basic;
                        empId = e.Current.Key;
                    }
                }

                return emps.GetValueOrDefault(empId);
            }

            public static Employee[] GetEmploeeArray()
            {
                return emps.Values.ToArray();
            }

            public static List<Employee> ConvertArrayToList()
            {
                Employee[] empArr = emps.Values.ToArray();
                return empArr.ToList<Employee>();
            }



            public override string ToString()
            {
                return "Employee [ Name: " + Name + ", EmpId:" + EmpNo + ",  DeptNo: " + DeptNo + ", Basic:" + Basic + " ]";
            }

        }

    }
}