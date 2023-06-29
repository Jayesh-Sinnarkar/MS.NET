namespace InheritanceExamples5
{
    class Program
    {
        static void Main()
        {
            //AbstractBaseClass1 o = new AbstractBaseClass1();  //error
            DerivedClass o = new DerivedClass();
            Console.ReadLine();
        }
    }
    public abstract class AbstractBaseClass1
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
    }
    public class DerivedClass : AbstractBaseClass1
    {

    }





    public abstract class AbstractBaseClass2
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
        public abstract void Display2();
        public abstract void Display3();
    }
    public class DerivedClass2 : AbstractBaseClass2
    {
        public override void Display2()
        {
            Console.WriteLine("d2");
        }

        public override void Display3()
        {
            Console.WriteLine("d3");
        }
    }

    public abstract class AbstractBaseClass3
    {
        
        public abstract void Display2();
        public abstract void Display3();
    }
    public abstract class DerivedClass3 : AbstractBaseClass3
    {
        public override void Display3()
        {
            Console.WriteLine("d3");
        }
    }

}

namespace InheritanceExamples5
{
    class Program
    {
        static void Main()
        {
            //AbstractBaseClass1 o = new AbstractBaseClass1();  //error
            Console.ReadLine();
        }
    }
    public abstract class AbstractBaseClass1
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
    }
    public class DerivedClass : AbstractBaseClass1
    {

    }
    public abstract class AbstractBaseClass2
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
        public abstract void Display2();
        public abstract void Display3();
    }
    public class Derived2 : AbstractBaseClass2
    {
        public override void Display2()
        {
            Console.WriteLine("d2");
        }
        public override void Display3()
        {
            Console.WriteLine("d3");
        }
    }
}
/*
        				Abstract Class		Sealed Class
Can be instantiated		    NO  			YES
can be used as a base class	YES 			NO
*/
//to do --- create a sealed class