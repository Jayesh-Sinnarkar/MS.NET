using System.ComponentModel.DataAnnotations;

namespace EMSFinal.Models
{
    public class LoginViewModel
    {
        [Key]
        public string Email { get; set; }

        public string Passwd { get; set; }
    }
}
