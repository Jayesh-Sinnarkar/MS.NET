using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAssignment1
{
    public class Employee
    {
        //EMPLOYEE NAME
        private string? name;
        public string? Name
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    throw new InvalidValueException("Invalid Name");
            }

            get { return name; }
        }

        private static int empCount = 0;
        public static int EmpCount { set { empCount = value; } get { return empCount; } }

        //EMPLOYEE ID
        private int empId;
        public int EmpId
        {
            set
            {
                if (value != 0)
                    empId = value;
                else throw new InvalidValueException("Invalid EmpNo");
            }
            get { return empId; }
        }

        //EMPLOYEE CITY
        private string? city;
        public string? City
        {
            get { return city; } 
            set {
                    if(!string.IsNullOrEmpty(value))
                        city = value;
                    else throw new InvalidValueException("Invalid EmpNo");
            }
        }

        //EMPLOYEE LEAVE STATUS
        private bool leaveStatus; 
        public bool LeaveStatus { set; get;}

        //CONSTRUCTORS
        public Employee(String name = "", String city = "")
        {
            EmpCount++;
            EmpId = EmpCount;
            Name = name;
            City = city;
            LeaveStatus = false;
        }

        //EVENT
        public event EventHandler OnLeave;

        //METHODS
        public void GoOnLeave()
        {
            LeaveStatus = true;
            OnLeave(this, EventArgs.Empty);
            Console.WriteLine($"Employee {this.Name} is on leave.");
        }

        //OVERLOADED ToString
        public override string ToString()
        {
            return "Employee [ EmpID: "+EmpId+", Name: "+Name+", City: "+city+" Is on Leave: "+leaveStatus+" ]";
        }
    }

}
