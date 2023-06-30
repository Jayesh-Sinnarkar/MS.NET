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
            Employee employee = new CEO("Jayesh", 1001, 150000);
            Console.WriteLine(employee);
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
            set
            {
                if (value > 0)
                    empNo = value;
            }
            get { return empNo; }
        }




        //ABSTRACT BASIC SALARY
        public abstract decimal Basic { set; get; }
        

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
        //OVERRIDEN BASIC SALARY PROPERTY
        public override decimal Basic
        {
            set
            {
                if (80000 >= value && value > 30000)
                    Basic = value;
                else Console.WriteLine("Invalid salary");
            }
            get { return Basic; }
        }

        //CALLING SUPER CLASS CTOR
        public Manager(String Designation="", string name = "", short deptNo = 0, decimal basic = 0) : base(name,deptNo,basic)
        {
            this.Designation = Designation;
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
            return 12 + 50000;
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

        private decimal _base;
        public override decimal Basic
        {
            set
            {
                if (50000 >= value && value > 15000)
                    _base = value;
                else Console.WriteLine("Invalid salary");

            }
            get { return _base; }
        }



        //CALLING SUPER CLASS CTOR
        public GeneralManager(string perks = "", string designation="", string name = "", short deptNo = 0, decimal basic = 0) : base(name,designation,deptNo,basic)
        {
            this.Perks = perks;
        }




        //CalcNetSalary()
        public override decimal CalcNetSalary()
        {
            return base.Basic+25000;
        }


        //Override ToString
        public override string ToString()
        {
            return "General Manager [ "+base.ToString() + " Perks: " + Perks+" ]";
        }
    }

    class CEO : Employee, IDBFunctions
    {

        //OVERRIDEN BASIC SALARY PROPERTY
        private decimal _basic;
        public override decimal Basic
        {
            set
            {
                if (150000 >= value && value > 15000)
                {
                    _basic = value;
                }
                else Console.WriteLine("Invalid Basic Salary");
            }
            get { return _basic; }
        }





        //CALLING SUPER CLASS CTOR
        public CEO( string name = "", short deptNo = 0, decimal basic = 0) : base(name, deptNo, basic)
        {
            this.Basic = basic;
        }


        //CalcNetSalary()
        public sealed override decimal CalcNetSalary()
        {
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