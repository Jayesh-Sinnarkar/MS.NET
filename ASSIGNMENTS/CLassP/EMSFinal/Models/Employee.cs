using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMSFinal.Models;

public partial class Employee
{

    
    public int EmpNo { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwd { get; set; } = null!;

    public int DeptNo { get; set; }

    public virtual Department? DeptNoNavigation { get; set; } = null!;
}
