namespace RefAndValue2
{
    internal class Program
    {
        static void Main1()
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2;
            o2 = "300";
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }
        //Boxing/Unboxing
        static void Main123()
        {
            int i = 100;  //value type
            object obj;
            obj = i;  //Boxing a value type

            int j;
            j = (int)obj;  //Unboxing 

        }
        static void DataTypes()
        {
            byte b; //Byte
            sbyte sb; //SByte
            short sh; //Int16  //2
            ushort ush; //UInt16  //2
            int i; //Int32 //4
            uint ui; //UInt32 //4
            long l; //Int64 //8
            ulong ul; //UInt64 //8

            float f; //Single
            double d; //Double
            decimal c; //Decimal

            char ch; //Char - 2 byte
            bool boo; //Boolean

            object o; //Object
            string st; //String

        }

        static void Main3()
        {
            int i ;
            int j ;
            Init(out i, out j);
            Swap(ref i,ref j);
            Print(in i);
            Print(j);
            //Console.WriteLine(i);
            //Console.WriteLine(j);
        }
        static void Swap(ref int a,ref int b)//a = i, b= j
        {

            int temp = a;
            a = b;
            b = temp;
        }
        //out is similar to ref - changes made in func reflect back in calling code
        //the initial value is discarded
        //out variables MUST be initialized in the function
        static void Init(out int a, out int b)
        {
            a = 100;
            b = 200;
        }
        static void Print(in int i)
        {
            Console.WriteLine(i);
            //i = 100;//error -- in variables are read only
        }

    }
}

namespace RefAndValueTypes3 //passing reference types
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething1(o);
            //DoSomething2(o);
            DoSomething3(ref o);
            Console.WriteLine(o.i);
        }
        static void DoSomething1(Class1 obj)  //obj = o
        {
            //changes made in func (changing value of properties) is reflected in calling code o
            obj.i = 200;
        }
        static void DoSomething2(Class1 obj)  //obj = o
        {
            //changes made in func (obj pointing to some other block) is NOT reflected in calling code o

            obj = new Class1();
            obj.i = 200;
        }
        static void DoSomething3(ref Class1 obj)  //obj = o
        {
            //changes made in func (obj pointing to some other block) is reflected in calling code o

            obj = new Class1();
            obj.i = 200;
        }

        //to do - try out and in with reference types
    }
    public class Class1
    {
        public int i;
    }
}