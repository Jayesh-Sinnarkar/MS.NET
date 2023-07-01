using System.Diagnostics;

namespace LinqExample1
{
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main1()
        {
            AddRecs();
            //var retval = from single_object in collection select something;
            var emps = from emp in lstEmp select emp;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            foreach (var item in emps)
            {
                Console.WriteLine(item.Name);
            }

        }
        static void Main2()
        {
            AddRecs();
            //var retval = from single_object in collection select something;
            //var emps = from emp in lstEmp select emp.Name;
            var emps = from emp in lstEmp select emp.EmpNo;

            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }

        }
        static void Main3()
        {
            AddRecs();
            //var retval = from single_object in collection select something;
            var emps = from emp in lstEmp select new { emp.EmpNo, emp.Name };

            foreach (var item in emps)
            {
                Console.WriteLine(item.EmpNo);
            }

        }
        static void Main4()
        {
            AddRecs();
            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;

            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;

            //var emps = from emp in lstEmp
            //           where emp.Name.StartsWith("V")
            //           select emp;
            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

            Console.ReadLine();

        }
        static void Main5()
        {
            AddRecs();


            var emps = from emp in lstEmp
                           //where emp.Basic > 10000
                       orderby emp.Name
                       select emp;
            //var emps = from emp in lstEmp
            //           orderby emp.Name descending
            //           select emp;

            //var emps = from emp in lstEmp
            //           orderby emp.DeptNo ascending, emp.Name descending
            //           select emp;


            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

            Console.ReadLine();

        }
        static void Main6()
        {
            AddRecs();
            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select emp;

            var emps1 = from emp in lstEmp
                        join dept in lstDept
                              on emp.DeptNo equals dept.DeptNo
                        select dept;

            var emps2 = from emp in lstEmp
                        join dept in lstDept
                              on emp.DeptNo equals dept.DeptNo
                        select new { emp, dept };

            var emps3 = from emp in lstEmp
                        join dept in lstDept
                              on emp.DeptNo equals dept.DeptNo
                        select new { emp.Name, dept.DeptName };
            foreach (var item in emps3)
            {
                Console.WriteLine(item);
            }
            //foreach (var item in emps3)
            //{
            //    
            //}
            Console.ReadLine();
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }

}

namespace LinqExample2
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }

    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }

        static Employee GetEmps(Employee obj)
        {
            return obj;
        }

        static string GetEmps2(Employee obj)
        {
            return obj.Name;
        }
        static void Main1()
        {
            AddRecs();
            //var emps = from emp in lstEmp select emp;

            var emps = lstEmp.Select(GetEmps);
            var emps_anon = lstEmp.Select(delegate(Employee obj)
            {
                return obj;
            });
            var emps_lambda = lstEmp.Select(obj => obj);


            //var emps = from emp in lstEmp select emp.Name;
            var emps2 = lstEmp.Select(GetEmps2);
            var emps2_anon = lstEmp.Select(delegate(Employee obj)
            {
                return obj.Name;
            });
            var emps2_lambda = lstEmp.Select(obj => obj.Name);


            var emps2_anon2 = lstEmp.Select(delegate (Employee obj)
            {
                return new { obj.Name, obj.EmpNo };
            });
            var emps2_lambda2 = lstEmp.Select(obj => new { obj.Name, obj.EmpNo });



            foreach (var item in emps)
            {
                Console.WriteLine(item.Name);
            }

        }
        static void Main2()
        {
            AddRecs();
            var emps1 = lstEmp.Select(obj => obj);
            var emps2 = lstEmp.Select(obj => obj.Name);
            var emps3 = lstEmp.Select(obj => new { obj.Name, obj.EmpNo });
            foreach (var item in emps1)
            {
                Console.WriteLine(item.Name);
            }

        }
        static void Main3()
        {
            AddRecs();
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000
            //           select emp;


            //var emps1 = lstEmp.Select(obj => obj).Where(emp => emp.Basic > 10000);
            //var emps2 = lstEmp.Where(emp => emp.Basic > 10000);
            //var emps3 = lstEmp.Where(emp => emp.Basic > 10000).Select(obj => obj);

  //errror  //var emps1 = lstEmp.Select(obj => obj.Name).Where(emp => emp.Basic > 10000);

            var emps3 = lstEmp.Where(emp => emp.Basic > 10000).Select(obj => obj.Name);

        }

        static void Main4()
        {
            AddRecs();
            //var emps = from emp in lstEmp
            //orderby emp.Name
            //select emp;


            var emps1 = lstEmp.OrderBy(emp => emp.Name);
            var emps2 = lstEmp.OrderByDescending(emp => emp.Name);

            var emps = from emp in lstEmp
                       orderby emp.DeptNo ascending, emp.Name descending
                       select emp;

            var emps3 = lstEmp.OrderBy(emp => emp.DeptNo).ThenByDescending(emp => emp.Name); ;

            Console.WriteLine("Emps...");
            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(  );
            Console.WriteLine("Emps3...");
            foreach (var item in emps3)
            {
                Console.WriteLine(item);
            }


        }

        static void Main5()
        {
            AddRecs();
            //var emps = from emp in lstEmp
            //           join dept in lstDept
            //                 on emp.DeptNo equals dept.DeptNo
            //           select emp;
;

            var emps = lstEmp.Join(lstDept,emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=> emp);


            //var emps2a = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);



            var emps2a = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);
            var emps2b = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept);
            var emps2c = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.DeptNo);
            var emps2d = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept.DeptNo);
            var emps2e = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp, dept });
            var emps2f = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp.Name, dept.DeptName });

            foreach (var item in emps2f)
            {
                Console.WriteLine(item);
            }
            //foreach (var item in emps)
            //{
            //    //item.dept.DeptName;
            //}
            Console.ReadLine();
        }

        //deferred execution
        static void Main6()
        {
            AddRecs();
            var emps = from emp in lstEmp select emp;

            Console.WriteLine();
            lstEmp.RemoveAt(0);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();


            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
        }

        //immediate execution
        static void Main7()
        {
            AddRecs();
            var emps = from emp in lstEmp select emp;
            //immediate execution
            emps = emps.ToList();  //.ToArray .ToDictionary
            //Employee [] arrEmps = emps.ToArray();
            //Dictionary<int, Employee> d = emps.ToDictionary(e => e.EmpNo);

            Console.WriteLine();
            lstEmp.RemoveAt(0);
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
        }

        //Single
        static void Main8()
        {
            AddRecs();
            Employee emp = lstEmp.Single(e => e.EmpNo == 1); //one record = okay
            //Employee emp = lstEmp.Single(e => e.EmpNo == 10);  //no records = error
            //Employee emp = lstEmp.Single(e => e.Basic > 5000); //multiple records - error


            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 1); //one record = okay
            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 10); //no records=null
            //Employee emp = lstEmp.SingleOrDefault(e =>  e.Basic > 5000);//multiple records - error

            if (emp != null)
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            else
                Console.WriteLine("not found");
            Console.ReadLine();
        }

        //simple group
        static void Main()
        {
            AddRecs();
            var emps = from emp in lstEmp
                       group emp by emp.DeptNo;

            foreach (var item in emps)
            {
                Console.WriteLine(item.Key); //deptno
                foreach (var e in item)  //e is an Employee, item is a grouping of Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Maina()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select group1;


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Key); //deptno
                foreach (var e in emp)  //e is an Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
        static void Main9()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select new { group1, Count = group1.Count(), Max = group1.Max(x => x.Basic), Min = group1.Min(x => x.Basic) };


            foreach (var item in emps)
            {
                Console.WriteLine(item.group1.Key); //DeptNo
                Console.WriteLine(item.Count); //count
                Console.WriteLine(item.Min); //min
                Console.WriteLine(item.Max); //max
                //emp.group1.Key;  //DeptNo

                foreach (var e in item.group1)  //e is an Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
