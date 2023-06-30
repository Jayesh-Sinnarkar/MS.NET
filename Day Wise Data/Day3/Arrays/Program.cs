namespace Arrays
{
    internal class Program
    {
        static void Main1()
        {
            int[] arr = new int[5];
            //arr[0] .... arr[4]
            int j = 0;

            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write("enter value for arr[" + i.ToString() + "] : ");
                Console.Write("enter value for arr[" + i + "] : ");
                Console.Write("enter value for arr[{0}] : ", i);
                Console.Write($"enter value for arr[{i}] : ");  //string interpolation
                //arr[i] = int.Parse(Console.ReadLine());
                arr[i] = Convert.ToInt32(Console.ReadLine());

            }
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

        }

        static void Main2()
        {
            int[] arr1 = { 10, 20, 30, 40, 50 };
            int[] arr2 = new int[3] { 1, 2,3 };
           

            int pos = Array.IndexOf(arr1, 20);
            pos = Array.LastIndexOf(arr1, 20);
            pos = Array.BinarySearch(arr1, 20);

            //Array.Clear(arr1);
            //Array.Copy(arr1, arr2, arr1.Length);
            //Array.ConstrainedCopy()
            //int[] arr3 = (int[]) Array.CreateInstance(typeof(int), 3);
            Array.Reverse(arr1);
            Array.Sort(arr1);

            Console.WriteLine();
            foreach (int item in arr1)
            {
                Console.WriteLine(item);
            }
        }

        static void Main3()
        {
            //int[] arr = new int[5];
            int[,] arr1 = new int[5, 3];
            //arr[0,0] arr[0,1] arr[0,2]
            //arr[1,0] arr[1,1] arr[1,2]
            //arr[2,0] arr[2,1] arr[2,2]
            //arr[3,0] arr[3,1] arr[3,2]
            //arr[4,0] arr[4,1] arr[4,2]


            //int[,,] arr2 = new int[5, 3, 2];

            Console.WriteLine(arr1.Length); //15
            Console.WriteLine(arr1.Rank); //2 --- no of dimensions

            Console.WriteLine(arr1.GetLength(0)); // lenfght of 1st dimension -5
            Console.WriteLine(arr1.GetLength(1)); // lenfght of 2nd dimension -3

            Console.WriteLine(arr1.GetUpperBound(0)); // upper bound of 1st dimension -4

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    Console.Write($"enter value for arr[{i},{j}] : ");  
                    arr1[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    Console.WriteLine($"value for arr[{i},{j}] is {arr1[i,j]} ");
                }
            }

        }

        static void Main4()
        {
            //jagged
            int[][] arr = new int[4][];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = new int[x]
            //}

            arr[0] = new int[3]; // arr[0][0] arr[0][1] arr[0][2]
            arr[1] = new int[4]; // arr[1][0] arr[1][1] arr[1][2] arr[1][3]
            arr[2] = new int[2];//  arr[2][0] - arr [2][1]
            arr[3] = new int[3];//  arr[3][0] arr[3][1] arr[3][2]

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("enter value for subscript [{0}][{1}] : ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr[i][j]);

                }
            }
            Console.ReadLine();
        }
        static void Main()
        {
            //Employee obj;

            Employee[] arr = new Employee[4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Employee();
                Console.WriteLine("enter name ");
                //arr[i].Name = Console.ReadLine();
            }
        }

    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}