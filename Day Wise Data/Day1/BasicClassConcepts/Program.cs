//using System;

using n1;

namespace BasicClassConcepts
{
    internal class Program
    {
        static void Main1()
        {
            System.Console.WriteLine("H W");
            Console.WriteLine("h w");
            //n1.Class1
            
        }
        static void Main()
        {
            Class1 o; //o is a reference of Class1
            o = new Class1();  //new Class1() is an object of Class1 and o refers to this object
            o.Display();
            o.Display("Vikram");

            //Class1 o2 = new Class1();


            //positional parameters
            Console.WriteLine(o.Add(10, 5));
            Console.WriteLine(o.Add(10, 5, 3));

            //named parameters
            Console.WriteLine(o.Add(b: 5));
            Console.WriteLine(o.Add(10,c: 5));
            Console.WriteLine(o.Add(b: 5,c:10,a:3));


        }
    }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
        public void Display(string s)  //func overloading
        {
            Console.WriteLine("Display" + s);
        }

        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}
        //public int Add(int a, int b, int c)
        //{
        //    return a + b + c;
        //}

        public int Add(int a = 0, int b=0 , int c =0)  //optional parameters
        {
            return a + b + c;
        }

        public void DoSomething()
        {
            int i = 100;
            Console.WriteLine( i );
            LocalFunc();

            //local function
            //local func can only be called from within the defining function
            //implicitly private

            void LocalFunc()
            {
                //local func can access variable defined in the calling function

                Console.WriteLine(i);
            }
            //to do - try to overload a local func
            //-- try to have a local func inside another local func

        }

    }
}

namespace n1
{
    public class Class1
    {

    }
    namespace n2
    {
        public class Class2 { }
    }
}