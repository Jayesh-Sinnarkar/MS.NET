using System.Collections;

namespace CollectionsExample
{
    internal class Program
    {
        static void Main1()
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(10);
            objArrayList.Add("Vikram");
            objArrayList.Add(3.14);
            objArrayList.Add(true);

            objArrayList.Insert(0, "new");
            //objArrayList.AddRange(objArrayList2);
            //objArrayList.InsertRange(0, objArrayList2)


            objArrayList.Remove("Vikram");
            //objArrayList.Remove(10);
            //objArrayList.RemoveAt(10);
            //objArrayList.RemoveRange(0,count)

            //objArrayList.IndexOf
            //objArrayList.LastIndexOf
            //objArrayList.BinarySearch

            //objArrayList.Clear  -- remove all
            //objArrayList.Clone  --- to read on cloning - deep clone, shallow clone
            bool contains = objArrayList.Contains(10);

            //objArrayList.CopyTo(array)
            //objArrayList.Count
            ArrayList al2 = objArrayList.GetRange(0, 3);

            objArrayList.SetRange(0, al2);
            //objArrayList -- 10 20 30 40
            //al2 -- 1 2 
            //objArrayList -- 1 2 30 40

            //objArrayList.Sort
            //objArrayList.Reverse


            foreach (object item in objArrayList) 
            { 
                Console.WriteLine(item);
            }

        }

        static void Main3()
        {
            ArrayList objArrayList = new ArrayList();

            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(10);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(20);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(30);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(40);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(50);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(60);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(70);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(80);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.Add(90);
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

            objArrayList.TrimToSize();

            Console.WriteLine();
            Console.WriteLine($"Count={objArrayList.Count}, Capacity={objArrayList.Capacity}");

        }

        static void Main4()
        {
            //Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();
            objDictionary.Add(4, "Ananya");
            objDictionary.Add(1, "Vikram");
            objDictionary.Add(2, "Shweta");
            objDictionary.Add(3, "Harsh");

            //objDictionary.Add(3, "new"); //error


            objDictionary[5] = "new";
            objDictionary[1] = "changed";

            objDictionary.Remove(1);  //key
            objDictionary.RemoveAt(1); //index

            //objDictionary.Contains(key)
            //objDictionary.ContainsKey(key)
            //objDictionary.ContainsValue(value)

            //objDictionary.GetByIndex()
            //objDictionary.GetKey(index)
            IList objKeys = objDictionary.GetKeyList();
            IList objValues = objDictionary.GetValueList();

            //objDictionary.IndexOfKey
            //objDictionary.IndexOfValue

            ICollection keys = objDictionary.Keys;
            ICollection values = objDictionary.Values;

            //objDictionary.SetByIndex



            foreach (DictionaryEntry item in objDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);

            }

        }

        static void Main5()
        {
            Stack s = new Stack();
            s.Push("aaa");
            Queue q = new Queue();
            q.Enqueue("aa");
        }

        static void Main6()
        {
            List<int> objList = new List<int>();
            objList.Add(1);

            foreach (int item in objList)
            {
                Console.WriteLine(item);
            }

        }
        static void Main7()
        {

            SortedList<int, string> objSortedList = new SortedList<int, string>();

            objSortedList.Add(1, "Vikram");
            objSortedList.Add(4, "Ananya");
            objSortedList.Add(2, "Shweta");
            objSortedList.Add(3, "Harsh");

            foreach (KeyValuePair<int, string> item in objSortedList)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

        }

        static void Main8()
        {
            Stack<int> s = new Stack<int>();
            Queue<int> q = new Queue<int>();

        }

        static void Main9()
        {
            List<Employee> lstEmps = new List<Employee>();
            lstEmps.Add(new Employee { EmpNo = 1, Name = "Vik" });
            lstEmps.Add(new Employee { EmpNo = 2, Name = "Shw" });
            lstEmps.Add(new Employee { EmpNo = 3, Name = "Har" });
            lstEmps.Add(new Employee { EmpNo = 4, Name = "Ana" });

            foreach (Employee item in lstEmps)
            {
                Console.WriteLine(item.EmpNo);
                Console.WriteLine(item.Name);
            }

        }

        static void Main()
        {
            //List<Employee> lstEmps = new List<Employee>();
            SortedList<int, Employee> objDictionary = new SortedList<int, Employee>();
            objDictionary.Add(1, new Employee { EmpNo = 1, Name = "Vik" });
            objDictionary.Add(2, new Employee { EmpNo = 2, Name = "Vik" });
            objDictionary.Add(3, new Employee { EmpNo = 3, Name = "Vik" });
            objDictionary.Add(4, new Employee { EmpNo = 4, Name = "Vik" });

            foreach (KeyValuePair<int,Employee> item in objDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.Name);
            }
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}

//https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-7.0

//https://learn.microsoft.com/en-us/dotnet/standard/generics/collections

//https://learn.microsoft.com/en-us/dotnet/standard/collections/when-to-use-generic-collections?source=recommendations


//https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class