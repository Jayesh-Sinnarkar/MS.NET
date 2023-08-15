using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace WebAppTest1.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<SelectListItem> Departments { get; set; }

        
    }
}
