namespace AnonMethodsAndLambdas
{
    internal class Program
    {
        static void Main()
        {
            int a = 100;
            Action o1 = delegate()
            {
                Console.WriteLine("display called");
                Console.WriteLine(++a);
            };
            o1();

            Func<int,int,int> o2 = delegate(int a, int b)
            { 
                return a + b; 
            };
            Console.WriteLine(o2(10,5 ));

            Console.WriteLine(a);
        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}

namespace AnonMethodsAndLambdas2
{
    internal class Program
    {
       
        static void Main()
        {
            Func<int, int> o1 = delegate (int a)
            {
                return a * 2;
            };
            Console.WriteLine( o1(10));

            //Func<int, int> o2 = delegate (int a)
            //{
            //    return a * 2;
            //};

            //Func<int, int> o2 = (a) => a * 2;
            Func<int, int> o2 = a => a * 2;
            Console.WriteLine( o2(10));

            //GetNow
            Func<string> o3 = () => DateTime.Now.ToString();
            Console.WriteLine(o3());

            //IsEven
            Func<int,bool> o4 = i=> i % 2 == 0;
            Console.WriteLine(o4(10));

            Employee obj = new Employee { Basic = 12000 };
            Predicate<Employee> o5 = emp => emp.Basic > 10000;
            Console.WriteLine(o5(obj));
                

            Func<int,int,int> o6 = (a,b)=> a + b;
            Console.WriteLine( o6(10,3));
        }
        static int GetDouble(int a)
        {
            return a * 2;
        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}