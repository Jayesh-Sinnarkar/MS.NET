/*Generics
1. CDAC has certain number of batches. each batch has certain number of students
         accept number of batches. for each batch accept number of students.
         create an array to store mark for each student (1 student has only 1 subject mark)
        accept the marks.
        display the marks.*/

namespace ASSIGNMENT_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CDAC RECORDS !");
            //Reading no of batches
            Console.Write("Enter No of batches: ");
            int batchCOunt = Convert.ToInt32(Console.ReadLine());

            //Creating and initializing Batch[]
            Batch[][] cdacBatchArr = new Batch[batchCOunt][];
            for (int i = 0; i < batchCOunt; i++)
            {

                Console.Write($"Enter number of students in batch{i}:");
                int noOfStuds = Convert.ToInt32(Console.ReadLine());
                cdacBatchArr[i] = new Student[noOfStuds];
                for(int j = 0; j < cdacBatchArr[i].Length; j++)
                {
                    cdacBatchArr[i][j] = new Student();
                }
            }
            //Read Student Info
            Console.WriteLine("Student Information:");

            foreach (Batch[] batch in cdacBatchArr)
            {
                foreach (Student student in batch)
                {

                    Console.WriteLine();
                    Console.Write("Enter Student Name: ");
                    student.Name = Console.ReadLine();


                    Console.Write("Enter Student Marks:");
                    int sMarks = Convert.ToInt32(Console.ReadLine());
                    student.Marks = sMarks;

                }
            }

            //Display Student Info
            Console.WriteLine("Displaying Record");

            for (int i = 0; i < cdacBatchArr.Length; i++)
            {
                for (int j = 0; j < cdacBatchArr[i].Length; j++)
                {
                    Console.WriteLine(cdacBatchArr[i][j]);
                }
            }

        }
    }

    public class Batch
    {
        private int batchNo;
        public int BatchNo
        {
            get { return batchNo; }
            set
            {
                if (batchNo > 0)
                    batchNo = value;
                else Console.WriteLine("Invalid Batch Number!");
            }
        }



    }

    public class Student : Batch
    {
        private string? name;
        public string? Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else Console.WriteLine("Invalid Name Value");
            }
        }

        private int marks;
        public int Marks
        {
            get { return marks; }
            set
            {
                if (value > 0)
                    marks = value;
                else Console.WriteLine("Invalid Marks");
            }
        }


        public Student()
        {

        }

        public override string ToString()
        {
            return "Student [ Name: " + name + ", Marks: " + marks + " ]";
        }

    }




}