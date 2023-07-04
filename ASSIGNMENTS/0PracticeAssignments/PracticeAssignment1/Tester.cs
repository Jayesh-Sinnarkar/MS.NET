using System.Net.Http.Headers;

namespace PracticeAssignment1
{
    internal class Tester
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("*****MENU*****\n"
                                     + "1.Register New Company\n"
                                     + "2.Select Registered Company \n"
                                     + "3.De-register Company \n"
                                     + "0. Exit.");
                    Console.Write("Enter your choice:");
                    int ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1://1. Register New Company
                            Console.Write("Enter Company Name to Register:");
                            String compName = Console.ReadLine();
                            CompanyUtils.RegisterCompany(compName);
                            break;

                        case 2://2. Select Registered Company
                            Console.Write("Enter Company Name: ");
                            Tester.SubMenu(Console.ReadLine());                          
                            break;

                        case 3://3. De-register Company
                            Console.Write("Enter Company Name to De-register:");
                            CompanyUtils.DeRegisterCompany(Console.ReadLine());
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
        public static void SubMenu(string cName)
        {
            CompanyUtils selectedComp =(CompanyUtils)CompanyUtils.SelectCompany(cName);
            
            bool exitCompany = false;
            while (!exitCompany)
            {
                try
                {
                    Console.WriteLine("               *****SUB-MENU*****\n"
                                     + "               A.Enroll Employee.\n"
                                     + "               B.Register Leave for Employee.\n"
                                     + "               C.Delete Employee Record.\n"
                                     + "               0. Exit.");
                    Console.Write("Enter your choice:");
                    char ch = Convert.ToChar(Console.ReadLine().ToUpper());

                    switch (ch)
                    {
                        case 'A'://1. Enroll Employee.
                            Console.Write("\nEnter Employee Name: ");
                            string? eName = Console.ReadLine();
                            Console.Write("\nEnter Employee City: ");
                            string? eCity = Console.ReadLine();
                            selectedComp.EnrollEmployee(eName, eCity);
                            break;

                        case 'B'://2. Register Leave for Employee.

                            break;

                        case 'C'://3. Delete Employee Record.
                            Console.Write("\nEnter Employee Name to Delete: ");
                            string? remEmp = Console.ReadLine();
                            selectedComp.DeleteEmployee(remEmp);
                            break;
                        case '0':
                            exitCompany = true;
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
} 

