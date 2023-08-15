using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEMS.Models
{
   
    
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Full Name is Required.")]
        [StringLength(30, ErrorMessage = "Name Shoud Not be Empty or more than 30 Characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email Id is Required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [MinLength(6)]
        [MaxLength(15)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone No is Required.")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10)]
        [MaxLength(15)]
        public string Phone { get; set; }


        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [MinLength(4)]
        [MaxLength(15)]
        
        public string Password { get; set; }
        public string Gender { get; set; }

        public int DeptNo { get; set; }
        public virtual Departmet department { get; set; }

    }

}


