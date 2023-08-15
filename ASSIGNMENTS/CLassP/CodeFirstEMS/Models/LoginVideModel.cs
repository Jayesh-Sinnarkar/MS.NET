
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEMS.Models
{
    public class LoginVideModel
    {
        [Required(ErrorMessage ="Login Name is Required.")]
        [EmailAddress]
        public string LoginName { get; set; }


        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
