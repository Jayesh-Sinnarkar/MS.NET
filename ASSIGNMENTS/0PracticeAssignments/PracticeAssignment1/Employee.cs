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

        //CONSTRUCTORS
        public Employee(String name = "", String city = "")
        {
            EmpCount++;
            EmpId = EmpCount;
            Name = name;
            City = city;
        }

        //OVERLOADED ToString
        public override string ToString()
        {
            return "Employee [ EmpID: "+EmpId+", Name: "+Name+", City: "+city+" ]";
        }
    }

}
