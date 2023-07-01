namespace ImplicitVariables
{
    //implicit variables
    internal class Program
    {
        static void Main1()
        {
            //int i = 0; 
            var i = 0;
            //i = "sss";
            //implicit variables
            //used only for local variables
            //cant be used for class level vars,fn params and return types
            Console.WriteLine(i);
            Console.WriteLine(i.GetType());
        }
    }
}

namespace AnonymousTypes
{
    //anonymous types
    internal class Program
    {
        static void Main2()
        {
            //Class1 o = new Class1{a=10,b="aaa",c=1.2};
            //var o = new {a=10,b="aaa",c=1.2};

            var o = new { Id = 10, Name = "aaa", Salary = 1.2 };
            var o2 = new { Id = 11, Name = "bbb", Salary = 3.2, IsRetired = true };
            Console.WriteLine(o.Id);
            Console.WriteLine(o.GetType());
            Console.WriteLine(o2.GetType());

        }
    }
}

namespace PartialClasses
{
    //PARTIAL CLASSES
    //partial classes must be in the same assembly
    //partial classes must be in the same namespace
    //partial classes must have the same name
    public partial class Class1
    {
        public int i;
    }
    public partial class Class1
    {
        public int j;
    }
    public class Program
    {
        public static void Main3()
        {
            Class1 o = new Class1();
            //o.
        }
    }
}

namespace PartialClasses
{
    public partial class Class1
    {
        public int k;
    }

}

namespace PartialMethods
{
    public class MainClass
    {
        public static void Main5()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }
    }
    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.
    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            //.....
            Validate();
            return isValid;
        }
    }
    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }


}

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main1()
        {
            int i = 100;
            i = i.Add(5);
            i.Display();
            i.ExtMethodForObjectClass();

            string s = "aaa";
            s.Show();
            s.ExtMethodForObjectClass();
        }
        static void Main2()
        {
            int i = 100;
            i = ExtMethodClass.Add(i, 5);
            ExtMethodClass.Display(i);

            string s = "aaa";
            ExtMethodClass.Show(s);
        }

        static void Main()
        {
            ClsMaths obj = new ClsMaths();
            Console.WriteLine(obj.Add(10, 5));
            Console.WriteLine(obj.Multiply(10, 5));
            Console.WriteLine(obj.Subtract(10, 5));

            obj.ExtMethodForObjectClass();

        }
    }
    public static class ExtMethodClass
    {
        public static int Add(this int i, int j)
        {
            return i + j;
        }
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static void Show(this string s)
        {
            Console.WriteLine( s );
        }
        //if you define an ext method for the base class, it is also available for the derived class
        public static void ExtMethodForObjectClass(this object o)
        {
            Console.WriteLine(o);
        }
        
        //if you define an ext method for an interface, it is also available
        //for all the classes that implement that interface
        public static int Subtract(this IMathOperations oIMath, int a , int b)
        {
            return a - b;
        }
    }


    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}