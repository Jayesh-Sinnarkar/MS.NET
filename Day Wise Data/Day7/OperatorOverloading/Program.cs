namespace OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o1 = new Class1 { i = 100 };
            Class1 o2 = new Class1 { i = 200 };
            o1 = o1 + 5;

            o2 = o2 - o1 ;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);
        }
    }
    public class Class1
    {
        public int i;
        public static Class1 operator+(Class1 o1, int i)
        {
            Class1 retval = new Class1();
            retval.i = o1.i + i;
            return retval;
        }
        public static Class1 operator -(Class1 o1, Class1 o2)
        {
            Class1 retval = new Class1();
            retval.i = o1.i -o2.i;
            return retval;
        }
    }
}