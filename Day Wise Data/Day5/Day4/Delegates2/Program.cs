namespace Delegates1
{

    //step 1 : create a delegate class that matches the signature of the function to call
    public delegate void Del1();
    //Object
    //Delegate
    //MulticastDelegate
    //Del1


    public delegate int DelAdd(int a, int b);
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
        static void Main4()
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

        static void Main5()
        {
            Del1 objDel = (Del1) Delegate.Combine(new Del1(Display), new Del1(Show));
            objDel();

            Console.WriteLine(  );
            objDel = (Del1)Delegate.Combine(objDel, new Del1(Display));
            objDel();

            Console.WriteLine();
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));
            objDel();

        }

        static void Main6()
        {
            //DelAdd objDelAdd = new DelAdd(Add);
            DelAdd objDelAdd = Add;
            objDelAdd += Subtract;
            //Console.WriteLine( objDelAdd(10, 5));
            int ans;
            ans = objDelAdd(10, 5);

            Console.WriteLine(ans);
        }

        static void Main7()
        {
            Del1 oDel = Class1.Display;
            oDel();

            Class1 obj = new Class1();
            oDel = obj.Show;
            oDel();
        }
        static void Display()
        {
            Console.WriteLine("display called");
        }
        static void Show()
        {
            Console.WriteLine("show called");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }

        //pass a function as a parameter
        static void Main()
        {
            Console.WriteLine(CallArithmeticOperation(Add,5,3));
            Console.WriteLine(CallArithmeticOperation(Subtract,6,2));
        }

        static int CallArithmeticOperation(DelAdd objDelAdd, int a, int b) //objDelAdd= Add
        {
            return objDelAdd(a, b);
        }

    }

    public class Class1
    {
        public static void Display()
        {
            Console.WriteLine("display called");
        }
        public void Show()
        {
            Console.WriteLine("show called");
        }
    }
}