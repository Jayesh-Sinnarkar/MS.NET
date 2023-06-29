using System.Runtime.CompilerServices;

namespace Properties
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
          
            //o.i = 1234;
            //Console.WriteLine(o.i);
            //o.i = o.i++ + ++o.i - o.i-- - --o.i;
            //o.SetI( o.GetI() );
            //o.SetI(1000);
            //Console.WriteLine( o.GetI() );

            o.I = 1000;  //set
            Console.WriteLine( o.I );  //get

            o.P3 = "";
            Console.WriteLine( o.P2 );
            o.P1 = "Jayesh";
           Console.WriteLine( o.P1 );   

        }
    }

    public class Class1
    {
        //private int i;  //class level variable / field
        //public void SetI(int VALUE)
        //{
        //    if (VALUE < 100)
        //        i = VALUE;
        //    else
        //        Console.WriteLine("invalid i");
        //}
        //public int GetI()
        //{
        //    return i;
        //}

        private int i;
        //property
        public int I
        {
            set 
            {
                if (value < 100)
                    i = value;
                else
                    Console.WriteLine("invalid i");
            }
            get 
            {
                return i;
            }
        }
        private string p1;
        public string P1
        {
            set 
            {
                p1 = value;

            }
            get 
            { 
                return p1; 
            }  
        }
        //to do : create a read only property
        private String p2 = "Jayesh";
        public string P2
        {
            get;
        }

        //automatic property/auto property
        //used when there are no validations

        //compiler generates code for get, set
        //compiler generates private variable for the property
        public string P3 { get; set; }

    }
}