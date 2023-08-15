using System;
using System.Collections.Generic;

namespace EFDBFirst.Models;

public partial class Employee
{
    public int EmoNo { get; set; }

    public string Name { get; set; } = null!;

    public decimal Basic { get; set; }

    public int DeptNo { get; set; }

    public virtual Department DeptNoNavigation { get; set; } = null!;
}
