namespace DefaultImplentationInInterfaces
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            //o.Select();

            (o as IDbFunctions).Select();

        }
    }

    public class Class1 : IDbFunctions
    {
        public void Display()
        {
            Console.WriteLine("display from class1");
        }
        public void Delete()
        {
            Console.WriteLine("idb.delete from class1");
        }

        public void Insert()
        {
            Console.WriteLine("idb.Insert from class1");
        }

        public void Update()
        {
            Console.WriteLine("idb.update from class1");
        }

        //public void Select()
        //{
        //    Console.WriteLine("idb.Select from class1");
        //}
        void IDbFunctions.Select()
        {
            Console.WriteLine("idb.Select from class1");
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();

        void Select()
        {
            Console.WriteLine("default implementation of idb.select - I1");
        }
    }
    public interface IDbFunctions2
    {
        void Insert();
        void Update();
        void Delete();

        void Select()
        {
            Console.WriteLine("default implementation of idb.select - I2");
        }
    }
}