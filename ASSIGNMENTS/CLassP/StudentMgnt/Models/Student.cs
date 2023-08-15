namespace StudentMgnt.Models
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Marks { get; set; }
        public string Div { get; set; }
        public int DeptNo { get; set; }

        public Student(int rollNo=0, string fname="", string lname = "", int marks = 0, string div = "", int deptNo = 0)
        {
            RollNo = rollNo;
            Fname = fname;
            Lname = lname;
            Marks = marks;
            Div = div;
            DeptNo = deptNo;
        }

    }
}
