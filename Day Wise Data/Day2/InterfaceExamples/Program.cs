namespace InterfaceExamples1
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.Delete();
            //method 1
            o.Display();

            //method 2
            IDbFunctions oIDb;
            oIDb = o;
            oIDb.Delete();

            //method 3
            ((IDbFunctions)o).Delete();

            //method 4
            (o as IDbFunctions).Delete();

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
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
}


namespace InterfaceExamples2
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.Insert();
            o.Update();

            (o as IDbFunctions).Delete();

            IFileFunctions oIFile;
            oIFile = o;
            oIFile.Open();
            oIFile.Close();
            oIFile.Delete();

        }
    }
    public class Class1 : IDbFunctions, IFileFunctions
    {
        public void Display()
        {
            Console.WriteLine("display from class1");
        }
        void IDbFunctions.Delete()
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

        //void IFileFunctions.Open()
        //{
        //    Console.WriteLine("ifile.open from class1");
        //}
        //void IFileFunctions.Close()
        //{
        //    Console.WriteLine("ifile.close from class1");
        //}
        void IFileFunctions.Delete()
        {
            Console.WriteLine("ifile.delete from class1");
        }
        public void Open()
        {
            Console.WriteLine("ifile.open from class1");
        }

        public void Close()
        {
            Console.WriteLine("ifile.close from class1");
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
}


namespace Interfaces3
{
    class Program
    {

        //polymorphic code
        static void Main1()
        {
            Class1 obj1 = new Class1();
            Class2 obj2 = new Class2();

            IDbFunctions oIDb;
            oIDb = obj1;
            oIDb.Insert();

            oIDb = obj2;
            oIDb.Insert();


            Console.ReadLine();
        }
        static void Main()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();
            InsertMethod(o1);
            InsertMethod(o2);
            Console.ReadLine();
        }
        static void InsertMethod(IDbFunctions oIDb) //can receive an object of any class that implements IDbFunctions
        {
            oIDb.Insert();
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }
    }
    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class2 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class2 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class2 - IDb.Update");
        }
    }
}



//advantages of interfaces

//contract - class MUST implement all the interface methods
//similar code in entire project for all developers
//polymorphic code
//design patterns 


//To DO -
//create an interface (I1)
//create a 2nd interface that inherits from I1