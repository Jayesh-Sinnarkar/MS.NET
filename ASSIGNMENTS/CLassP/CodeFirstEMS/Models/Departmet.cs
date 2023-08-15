using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEMS.Models
{
    public class Departmet
    {
        [Key]
        public int DeptId { get; set; }
        [DisplayName("Department Name")]
        public string DeptName { get; set;}
        ICollection<Employee> Employees { get; set; }
    }
}