using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAssignment1
{
    internal class CompanyUtils
    {
        public Company SelectedComp { 
            set; get; }



        //CONSTRUCTOR
        public CompanyUtils(Company comp)
        {
            SelectedComp = comp;
        }




        //ADD COMPANY
        public static void RegisterCompany(string name)
        {
            Company.companyList.Add(new Company(name));
            Console.WriteLine($"Company {name} added successfully.");
        }




        //REMOVE COMPANY
        public static string? DeRegisterCompany(string name)
        {
            Company? removableObj = null;
            foreach (Company company in Company.companyList)
            {

                if (company.CompanyName.Equals(name))
                {
                    removableObj = company;
                    Company.companyList.Remove(company);
                }
            }
            if (removableObj == null)
                throw new InvalidValueException($"Could not find company with name: {name}");
            Console.WriteLine($"Company {name} is Suceesfully Removed From Records.");
            return removableObj.CompanyName;
        }




        //RETRIVE PERTICULAR COMPANY BY NAME
        public static Company SelectCompany(string name)
        {
            Company? resultObj = null;
            foreach (Company company in Company.companyList)
            {
                if (company.CompanyName.Equals(name))
                {
                    resultObj = company;
                }
            }
            if (resultObj == null)
                throw new InvalidValueException($"Could not find company with name: {name}");
            Console.WriteLine($"You are Viewing Records of {name} Company....");
            return resultObj;
        }




        //ADD EMPLOYEE
        public void EnrollEmployee(string eName, string eCity)
        {
            Employee employee = new Employee(eName, eCity);

            if (!string.IsNullOrEmpty(employee.Name) && !string.IsNullOrEmpty(employee.City))
            {
                SelectedComp.employeeList.Add(employee);
                Console.WriteLine($"Employee {eName} added successfully...");
            }
            else throw new InvalidValueException("Could not add employee name or city value is invalid.");
        }




        //DELETE EMPLOYEE
        public Employee DeleteEmployee(string eName)
        {

            foreach (Employee employee in SelectedComp.employeeList)
            {
                if (employee.Name.Equals(eName))
                {
                    SelectedComp.employeeList.Remove(employee);
                    return employee;
                }
            }
            throw new InvalidValueException($"Employee name: {eName} you entered does not match with our records.");
        }

        //RETRIVE EMPLOYEE FROM SELECTED COMPANY
        public Employee RetriveEmployee(string eName)
        {
            foreach (Employee e in SelectedComp.employeeList)
            {
                if(e.Name.Equals(eName))
                {
                    return e;
                }
            }
            throw new InvalidValueException($"Employee {eName} Does Not Exists in Records.");
        }

        //Search EMPLOYEE IN ALL COMPANY RECORDS
        public Employee SearchEmployee(string eName)
        {
            foreach(Company c in Company.companyList)
            {
                foreach (Employee e in c.employeeList)
                {
                    if (e.Name.Equals(eName))
                        return e;
                }
            }
            throw new InvalidValueException($"Employee {eName} Does Not Exists In Any Company...");
        }

    }
}
