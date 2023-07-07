namespace ActionFuncPredicate
{
    internal class Program
    {
        static void Main1()
        {
            Action o1 = Display;
            o1();

            Action<string> o2 = Display;
            o2("aa");

            Action<string, int> o3 = Display;
            o3("aa", 10);
        }
        static void Main()
        {
            Func<string> o1 = GetNow;
            Console.WriteLine(o1());

            Func<int, bool> o2 = IsEven;
            Console.WriteLine(o2(10));

            Func<int, int, int> o3 = Add;
            Console.WriteLine( o3(10,5));

            Predicate<int> o4 = IsEven;
            Console.WriteLine(o4(10));

            Employee obj = new Employee { Basic = 12000 };
            Predicate<Employee> o5 = IsBasicMoreThan10000;
            Console.WriteLine(o5(obj));
        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static void Display(string s)
        {
            Console.WriteLine("display called" + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("display called" + s+i);
        }

        static string GetNow()
        {
            return DateTime.Now.ToString();
        }
        static bool IsEven(int i)
        {
            return i % 2 == 0;
            //if (i % 2 == 0)
            //    return true;
            //else
            //    return false;
        }
        static bool IsBasicMoreThan10000(Employee obj)
        {
            return obj.Basic > 10000;
            //if (obj.Basic > 10000)
            //    return true;
            //else
            //    return false;
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