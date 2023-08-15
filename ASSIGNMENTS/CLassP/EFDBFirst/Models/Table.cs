using System;
using System.Collections.Generic;

namespace EFDBFirst.Models;

public partial class Table
{
    public int DeptNo { get; set; }

    public string DeptName { get; set; } = null!;
}
