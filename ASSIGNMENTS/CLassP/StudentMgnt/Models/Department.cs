namespace StudentMgnt.Models
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string Dname { get; set; }

        public List<Student>? Students= new List<Student>();

        public Department(int deptNo=0, string dname="")
        {
            DeptNo = deptNo;
            Dname = dname;
        }
        public Department()
        {
            
        }

    }
}
