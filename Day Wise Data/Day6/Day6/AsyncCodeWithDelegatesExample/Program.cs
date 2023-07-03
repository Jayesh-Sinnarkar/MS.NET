using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCodeWithDelegatesExample1
{
    internal class Program
    {
        static void Main1()
        {
            Action oDel = Display;
            Console.WriteLine( "before" );
            oDel.BeginInvoke(null, null);
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static void Display()
        {
            Thread.Sleep( 3000 );
            Console.WriteLine( "display called" );
        }
    }
}

namespace AsyncCodeWithDelegatesExample2
{
    internal class Program
    {
        static void Main2()
        {
            Action<string> oDel = Display;
            Console.WriteLine("before");
            oDel.BeginInvoke("passed string", null, null);
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static void Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("display called" + s);
        }
    }
}

namespace AsyncCodeWithDelegatesExample3
{
    internal class Program
    {
        static void Main3()
        {
            Func<string,string> oDel = Display;
            Console.WriteLine("before");
            //oDel.BeginInvoke("passed string", new AsyncCallback(CallbackFunction), null);
            oDel.BeginInvoke("passed string", CallbackFunction, null);

            Console.WriteLine("after");
            Console.ReadLine();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback func called after Display is over");
        }
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}

namespace AsyncCodeWithDelegatesExample4
{
    internal class Program
    {
        static void Main1()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("before");
            //oDel.BeginInvoke("passed string", new AsyncCallback(CallbackFunction), null);
            IAsyncResult ar = oDel.BeginInvoke("passed string",  delegate(IAsyncResult ar2)
            {
                string retval = oDel.EndInvoke(ar2);
                Console.WriteLine("callback func called after Display is over");
                Console.WriteLine(retval);
            }, null);


            Console.WriteLine("after");
            Console.ReadLine();
        }
       
        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}

namespace AsyncCodeWithDelegatesExample5
{
    internal class Program
    {
        static void Main()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("before");
            //oDel.BeginInvoke("passed string", new AsyncCallback(CallbackFunction), null);
            IAsyncResult ar = oDel.BeginInvoke("passed string", null, null);

            Console.WriteLine("after");

            while (!ar.IsCompleted) ;
            string retval = oDel.EndInvoke(ar);
            Console.WriteLine(retval);
            Console.ReadLine();
        }

        static string Display(string s)
        {
            Thread.Sleep(3000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}


