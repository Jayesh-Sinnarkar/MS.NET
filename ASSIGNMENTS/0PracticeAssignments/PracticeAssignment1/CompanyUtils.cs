using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAssignment1
{
    internal class CompanyUtils : Company
    {
        //CONSTRUCTOR
        public CompanyUtils(string name) : base(name) { }

        //ADD COMPANY
        public static void RegisterCompany(string name)
        {
            companyList.Add(new Company(name));
            Console.WriteLine($"Company {name} added successfully.");
        }

        //REMOVE COMPANY
        public static string? DeRegisterCompany(string name)
        {
            Company? removableObj = null;
            foreach (Company company in companyList)
            {
                 
                if (company.CompanyName.Equals(name))
                {
                    removableObj = company;
                    companyList.Remove(company);
                }
            }
            if (removableObj == null)
                throw new InvalidValueException($"Could not find company with name: {name}");
            return removableObj.CompanyName;   
        }

        //RETRIVE PERTICULAR COMPANY BY NAME
        public static Company SelectCompany(string name)
        {
            Company? resultObj = null;
            foreach (Company company in companyList)
            {
                if (company.CompanyName.Equals(name))
                {
                    resultObj = company;
                }
            }
            if (resultObj == null)
                throw new InvalidValueException($"Could not find company with name: {name}");
            return resultObj;
        }

        //ADD EMPLOYEE
        public void EnrollEmployee(string eName, string eCity)
        {
            Employee employee = new Employee(eName,eCity);
            if (!string.IsNullOrEmpty(employee.Name) && !string.IsNullOrEmpty(employee.City))
            {
                employeeList.Add(employee);
                Console.WriteLine("Employee added successfully...");
            }
            else throw new InvalidValueException("Could not add employee name or city value is invalid.");
        }

        public Employee DeleteEmployee(string eName)
        {
            
            foreach (Employee employee in employeeList)
            {
                if (employee.Name.Equals(eName))
                {
                    employeeList.Remove(employee);
                    return employee;
                }             
            }
            throw new InvalidValueException($"Employee name: {eName} you entered does not match with our records.");
        }
        
    }
}
