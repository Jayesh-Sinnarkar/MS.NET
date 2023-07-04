using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAssignment1
{
    public class Company
    {
        //COMPANY ID
        private static int companyCount = 0;
        private int companyId;
        public int CompanyId
        {
            set
            {
                if (value > 0)
                    companyId = value;
                else
                    throw new InvalidValueException("Company Id should not be less than 0.");
            }
            get { return companyId; }
        }


        //COMPANY NAME
        private string? companyName;
        public string? CompanyName
        {
            get { return companyName; }
            set
            {
                if (!string.IsNullOrEmpty(value)) companyName = value;
                else throw new InvalidValueException("Company Name Should Not be Null or Empty");
            }
        }

        //COMPANY COLLECTION
        protected static List<Company> companyList = new List<Company>();
        //EMPLOYEE COLLECTION
        protected List<Employee> employeeList = new List<Employee>();

        //CONSTRUCTORS
        public Company(string name)
        {
            CompanyName = name;
            companyCount++;
            CompanyId = companyCount;
        }
    }
}
