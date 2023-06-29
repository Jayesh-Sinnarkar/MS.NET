namespace Delegates1
{

    //step 1 : create a delegate class that matches the signature of the function to call
    public delegate void Del1();
    //Object
    //Delegate
    //MulticastDelegate
    //Del1
    internal class Program
    {
        static void Main1()
        {
            
            //step 2 : create a delegate reference and a delegate object and pass function name as a parameter
            Del1 objDel = new Del1(Display);

            //step 3 : call the func indirectly using the delegate reference
            objDel();
        }
        static void Main2()
        {
            Del1 objDel = Display;
            objDel();
        }
        static void Main3()
        {
            Del1 objDel = Display;
            objDel();

            objDel = Show;
            objDel();

        }
        static void Main()
        {
            Del1 objDel = Display;
            objDel();

            Console.WriteLine();
            objDel += Show;
            objDel();

            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.WriteLine();
            objDel -= Show;
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static void Show()
        {
            Console.WriteLine("show called");
        }
    }
}