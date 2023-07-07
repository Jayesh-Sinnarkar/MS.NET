namespace EventHandling1
{
    internal class Program
    {
        //static void Main()
        //{
        //    Class1 obj = new Class1();
        //    obj.InvalidP1 += obj_InvalidP1;
        //    obj.P1 = 200;
        //}
        //static void obj_InvalidP1()
        //{
        //    Console.WriteLine("event handling code called");
        //}

        static void Main1() 
        { 
            Class1 obj = new Class1();
            obj.InvalidP1 += Obj_InvalidP1;
            obj.InvalidP1 += Handler2;
            obj.P1 = 200;

        }

        private static void Obj_InvalidP1()
        {
            Console.WriteLine("event handling code here");
        }
        private static void Handler2()
        {
            Console.WriteLine("event handling code here -2");
        }
    }



    //step 1 : create a delegate class that matches the event handler
    public delegate void InvalidP1EventHandler();
    public class Class1
    {
        //step 2 - declare the event
        //event is actually a delegate reference

        public event InvalidP1EventHandler InvalidP1;


        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3  raise the event whenever required
                    if(InvalidP1 != null)
                        InvalidP1();
                }
            }
        }
    }
}

namespace EventHandling2
{
    internal class Program
    {
        
        static void Main()
        {
            Class1 o = new Class1();
            o.InvalidP1 += O_InvalidP1;
            o.P1 = 200;
        }

        private static void O_InvalidP1(int InvalidValue)
        {
            Console.WriteLine( $"event handled. invalid value is {InvalidValue}" );
        }
    }



    //step 1 : create a delegate class that matches the event handler
    public delegate void InvalidP1EventHandler(int InvalidValue);
    public class Class1
    {
        //step 2 - declare the event
        //event is actually a delegate reference

        public event InvalidP1EventHandler InvalidP1;


        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3  raise the event whenever required
                    if (InvalidP1 != null)
                        InvalidP1(value);
                }
            }
        }
    }
}