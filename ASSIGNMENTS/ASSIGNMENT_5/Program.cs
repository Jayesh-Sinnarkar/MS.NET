/*
 Name: Jayesh Sinnarkar
 
1.Declare a dictionary based collection of Employee class objects
Accept details for Employees  in a loop. Stop accepting based on user input (yes/no)'
Display the Employee with highest Salary
Accept EmpNo to be searched. Display all details for that employee.
Display details for the Nth Employee where N is a number accepted from the user.


2. Create an array of Employee objects. Convert it to a List<Employee>.  Display all the Employees in the list.

3. Create a List<Employee>. Convert it to an array. Display all the array elements.

 */

namespace ASSIGNMENT_5
{
    internal class Program
    {
        static void Main()
        {
            StubbedData.staticAddStubbedData();
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("*****MENU*****\n"
                                     + "1. Create New Employee Record.\n"
                                     + "2. Display Employee With Highest Salary.\n"
                                     + "3. Display List of All Employees.\n"
                                     + "4. Display Array of All Employees.\n"
                                     + "5. Display Details of Nth Employee.\n"
                                     + "0. Exit.");
                    Console.Write("Enter your choice:");
                    int ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1://1. Create New Employee Record.
                            Console.Write("Enter No of Employees to register: ");
                            int empCount = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < empCount; i++)
                            {
                                Console.WriteLine($"\nEnter Employee {i + 1} Details.");
                                Console.Write("Enter Employee Name:");
                                string name = Console.ReadLine();
                                Console.Write("Enter Employee Department No:");
                                short deptNo = Convert.ToInt16(Console.ReadLine());
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
                            while (e.MoveNext())
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
                        case 5://5. Display Details of Nth Employee.
                            Console.Write("Enter index to find employee:");
                            int index = Convert.ToInt32(Console.ReadLine());
                            Employee employee = Employee.getEmpByIndex(index);
                            Console.WriteLine();
                            Console.WriteLine($"Employee at {index} index is: ");
                            Console.WriteLine(employee);
                            break;

                        case 0:
                            exit = true;
                            Console.WriteLine("Thank you...");
                            break;

                        default:
                            throw new Exception("Invalid Input.");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
                decimal highestSal = 0;
                int empId = 0;
            
            foreach (KeyValuePair<int,Employee> pair in emps)
            {
                if (pair.Value.Basic > highestSal)
                {
                    empId = pair.Key;
                    highestSal = pair.Value.Basic;
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

            public static Employee getEmpByIndex(int index)
            {
                return  emps.ElementAtOrDefault(index).Value;                
            }


            public override string ToString()
            {
                return "Employee [ Name: " + Name + ", EmpId:" + EmpNo + ",  DeptNo: " + DeptNo + ", Basic:" + Basic + " ]";
            }

            
        }
    public class StubbedData
    {
        public static void staticAddStubbedData()
        {
            Employee.AddEmpToRecord("Jayesh", 101, 200000);
            Employee.AddEmpToRecord("Divyanshu", 101, 300000);
            Employee.AddEmpToRecord("Ashish", 103, 150000);
            Employee.AddEmpToRecord("Harshad", 103, 120000);
            Employee.AddEmpToRecord("Pranay", 106, 125000);
            Employee.AddEmpToRecord("Tushar", 106, 175000);
            Employee.AddEmpToRecord("Vipul", 108, 75000);
            Employee.AddEmpToRecord("Harshal", 108, 200000);
            Employee.AddEmpToRecord("Vaibhav", 109, 200000);
            Employee.AddEmpToRecord("Avanish", 109, 300000);
        }
    }
    
}