namespace StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1.si = 10000;
            Class1 o2 = new Class1();
            Class1 o1;
            o1 = new Class1();
            o1.i = 100;
            o2.i = 200;
            o1.Display();
            Class1.sDisplay();
            Class1.P2 = 10;
        }
    }
    public class Class1
    {
        //static variable? - single copy 
        public static int si;
        public int i;

        public void Display()
        {
            Console.WriteLine("Display");
            Console.WriteLine(i);
            Console.WriteLine(si);

        }
        //static function? - can be accessed as Classname.function,
        //no need to create an object for accessing the static function

        public static void sDisplay()
        {
            Console.WriteLine("static  Display");
            //Console.WriteLine(i); //error
            Console.WriteLine(si);

        }

        private int p1;
        public int P1
        {
            set
            {
                if (value < 100)
                    p1 = value;
                else
                    Console.WriteLine("invalid value");
            }
            get
            {
                return p1;
            }
        }
        private static int p2;
        public static int P2
        {
            set
            {
                if (value < 100)
                    p2 = value;
                else
                    Console.WriteLine("invalid value");
            }
            get
            {
                return p2;
            }
        }

        static Class1()
        {
            Console.WriteLine("static cons called");
        }
    }
}

//static variable? - single copy 
//property? - validations
//static property? - single copy with validations

//constructor? - initialize data members
//static constructor? - initialize static data members

//when is the static cons called? - when the class is loaded
//when is the class loaded into memory?
//- when the first object is created
//OR a static member is accessed for the first time
//static cons is implicitly called
// static cons is parameterless and therefore cannot be overloaded
//static cons is implicitly private

//static class //TO DO
//can only have static members
//cannot be instantiated
//cannot be used as a base class
