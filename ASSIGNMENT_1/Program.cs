namespace ASSIGNMENT_1
{
    internal class Employee
    {
        static void Main()
        {
            Employee employee1 = new Employee() {Name="Jayesh", empNo=100, DeptNo=101, Basic=100000 };
            Employee employee2 = new Employee() { Name = "Aditya", empNo = 200, DeptNo = 102, Basic = 50000 };

            Console.WriteLine(employee1);
            Console.WriteLine(employee2);

            
        }

        private string? name;
        public string Name
        { 
            set{
                if (value.Length != 0 || value != null)
                    name = value;
                else
                    System.Console.WriteLine("Invalid Name Input");
            }

            get { return name; }
        }

        private int empNo;
        public int EmpNo
        {   
            set {
                    if (value != 0)
                        empNo = value;           
             }
            get { return empNo; }
        }

        private decimal basic;
        public decimal Basic
        {
            set {
                if(100000>=value && value>= 50000)
                    basic= value;
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

        public decimal GetNetSalary()
        {
            return  basic * 12;
        }

        

        public override string ToString()
        {
            return "Employee [ Name: "+Name+", EmpId:"+EmpNo+ ",  DeptNo: "+DeptNo+", Basic:" +Basic+" ]";
        }

    }
}


/*
 string Name -> no blank names should be allowed
int EmpNo -> must be greater than 0
decimal Basic -> must be between some range
short DeptNo -> must be > 0

Methods
-------
decimal GetNetSalary() -> returns calculated net salary (Use any formula to get net salary based on Basic salary)
 */