namespace ConstructorsAndObjectInitializers
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            Class1 o2 = new Class1(100,200,300);
            Console.WriteLine(o.P1);
            
        }
    }
    public class Class1
    {
        //public Class1()
        //{
        //    Console.WriteLine("no param Cons called");
        //    P1 = 10;
        //    P2 = 20;
        //    P3 = 30;
        //}
        //public Class1(int P1, int P2, int P3)
        //{
        //    Console.WriteLine("param Cons called");
        //    this.P1 = P1;
        //    this.P2 = P2;
        //    this.P3 = P3;
        //}

        //public Class1(int P1, int P2)
        //{
        //    Console.WriteLine("param Cons called");
        //    this.P1 = P1;
        //    this.P2 = P2;
        //    this.P3 = 30;
        //}
        //public Class1(int P1)
        //{
        //    Console.WriteLine("param Cons called");
        //    this.P1 = P1;
        //    this.P2 = 20;
        //    this.P3 = 30;
        //}
        public Class1(int P1 = 10, int P2 = 20, int P3 = 30)
        {
            Console.WriteLine("param Cons called");
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }
        ~Class1() //DONT EVER WRITE THIS
        {
            Console.WriteLine("destructor called");
        }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }

    }
}

namespace ObjectInitializers
{
    internal class Program
    {
        static void Main()
        {
            Class1 o1 = new Class1();
            o1.P1 = 10;
            o1.P2 = 20;
            o1.P3 = 30;

            //object initializer
            Class1 o2 = new Class1() { P1 = 10, P2 = 20, P3 = 30 };
            Console.WriteLine(o2.P1);
            Console.WriteLine(o2.P2);
            Console.WriteLine(o2.P3);
            Class1 o3 = new Class1 { P1 = 10, P2 = 20};
            Console.WriteLine(o3.P1);
            Console.WriteLine(o3.P2);
            Console.WriteLine(o3.P3);

            // Class1 o4 = new Class1(10) { P2 = 20, P3 = 30 };


        }
    }
    public class Class1
    {
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
    }
}
