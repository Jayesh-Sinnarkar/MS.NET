﻿/***********************ASSIGNMENT 03***********************
Create the following classes
Employee
   Prop	
	string Name -> no blanks
	int EmpNo -> readonly, autogenerated
	short DeptNo -> > 0

    abstract decimal Basic

   Methods
    abstract decimal CalcNetSalary()


Manager: Employee
   Prop

    string Designation -> cant be blank
	

GeneralManager : Manager
   Prop
 	string Perks -> no validations

CEO : Employee
      Make CalNetSalary() a sealed method

NOTE : Overloaded constructors in all classes calling their base class constructor
All classes must implement IDbFunctions interface
All classes to override the abstract members defined in the base class(Employee). Basic property to have different validation in different classes.
*/
namespace ASSIGNMENT_3
{
    public interface IDBFunctions
    {
        void insert();
        void update();
        void delete();
    }

    public class Assignment3
    {
        public static void Main()
        {
            Employee employee = new CEO("Jayesh", 1001, 15500);
            Console.Write(employee.CalcNetSalary());
            Console.WriteLine("\n"+employee);
            Console.WriteLine();

            Employee employee2 = new Manager("OpsMgr", "Shubham", 1002, 50000);
            Console.WriteLine(employee2.CalcNetSalary());
            Console.WriteLine(employee2);
            Console.WriteLine();

            Employee employee3 = new GeneralManager("Car", "GRPM", "Vaibhav", 1003, 25000);
            Console.WriteLine(employee3.CalcNetSalary());
            Console.WriteLine(employee3);
            Console.WriteLine();

        }
    }


    public abstract class Employee 
    {
        
        //NAME
        private string name="";
        public string Name
        {
            set
            {
                if (value.Length > 0 || value != null)
                    name = value;
                else
                    System.Console.WriteLine("Invalid Name Input");
            }

            get { return name; }
        }




        //EMPID - auto generated id
        private static int empCount = 0;
        public static int EmpCount { set { empCount = value; } get { return empCount; } }

        private int empNo = 0;
        public int EmpNo
        {
            private set { empNo = value; } 
            get { return empNo; }
        }




        //ABSTRACT BASIC SALARY
        protected abstract decimal Basic { set; get; }
        

        //DEPARTMENT NO
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


        //OPTIONAL PARAM CONSTRUCTOR
        public Employee(string Name = "Aditya", short DeptNo = 102, decimal Basic = 50000)
        {
            this.Name = Name;
            this.DeptNo = DeptNo;
            this.Basic = Basic;
            EmpCount++;
            EmpNo = EmpCount;
        }

        //CalcNetSalary();
        public abstract decimal CalcNetSalary();


        public override string ToString()
        {
            return " Name: " + Name + ", EmpId:" + EmpNo + ",  DeptNo: " + DeptNo + ", Basic:" + Basic+" ";
        }

    }
    class Manager : Employee, IDBFunctions
    {
        private decimal mbasic;
        //OVERRIDEN BASIC SALARY PROPERTY
        protected override decimal Basic
        {
            set
            {
                if (80000 >= value && value > 30000)
                    mbasic = value;
                else Console.WriteLine("Invalid salary - Manager");
            }
            get { return mbasic; }
        }

        //CALLING SUPER CLASS CTOR
        public Manager(String Designation="", string name = "", short deptNo = 0, decimal mbasic = 0) : base(name,deptNo,mbasic)
        {
            this.Designation = Designation;
            this.Basic= mbasic;
        }


        //DESIGNATION
        private string designation="";
        public string Designation
        {
            set
            {
                if (value != "" && value != null)
                    designation = value;
                else Console.WriteLine("Invalid Designation");
            }

            get { return designation; }
        }

        //CalcNetSalary()
        public override decimal CalcNetSalary()
        {
            Console.Write("\nManager Salary: ");
            return Basic * 12 + 50000;
        }

        //IDBFunction Interface Methods
        public void insert()
        {
            Console.WriteLine("Employee class - insert method");
        }

        public void update()
        {
            Console.WriteLine("Employee class - update method");
        }

        public void delete()
        {
            Console.WriteLine("Employee class - delete method");
        }


        //Override ToString
        public override string ToString()
        {
            return "Manager ["+base.ToString() + " Designation: "+designation+" ]";
        }
    }

    class GeneralManager : Manager, IDBFunctions {

        //perks
        private string? perks = "";
        public string? Perks { set; get; }



        
        //OVERRIDEN BASIC SALARY PROPERTY

        private decimal gbase;
        protected override decimal Basic
        {
            set
            {
                if (50000 >= value && value > 15000)

                    gbase = value;
                else Console.WriteLine("Invalid salary");

            }
            get { return gbase; }

   
        }



        //CALLING SUPER CLASS CTOR
        public GeneralManager(string perks = "", string designation="", string name = "", short deptNo = 0, decimal gbasic = 0) : base(designation, name,deptNo,gbasic)
        {
            this.Perks = perks;
        }




        //CalcNetSalary()
        public override decimal CalcNetSalary()
        {

            return Basic+25000;

        }


        //Override ToString
        public override string ToString()
        {
            return "General Manager [ "+ " Name: " + Name + ", EmpId:" + EmpNo + ",  DeptNo: " + DeptNo + ", Basic:" + Basic + " " + " Perks: " + Perks + " Designation: " + Designation + " ]";
        }
    }

    class CEO : Employee, IDBFunctions
    {

        //OVERRIDEN BASIC SALARY PROPERTY
        private decimal cbasic;
        protected override decimal Basic
        {
            set
            {
                if (150000 >= value && value > 15000)
                {
                    cbasic = value;
                }
                else Console.WriteLine("Invalid Basic Salary - CEO");
            }
            get { return cbasic; }
        }





        //CALLING SUPER CLASS CTOR
        public CEO( string name = "", short deptNo = 0, decimal cbasic = 0) : base(name, deptNo, cbasic)
        {
            this.Basic = cbasic;
        }


        //CalcNetSalary()
        public sealed override decimal CalcNetSalary()
        {
            Console.Write("CEO Salary: ");
            return Basic + 250000;
        }





        //IDBFunction Interface Methods
        public void insert()
        {
            Console.WriteLine("CEO class - insert method");
        }

        public void update()
        {
            Console.WriteLine("CEO class - update method");
        }

        public void delete()
        {
            Console.WriteLine("CEO class - delete method");
        }

        public override string ToString()
        {
            return "CEO ["+base.ToString()+"]";
        }
    }
}