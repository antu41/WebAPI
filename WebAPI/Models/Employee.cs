using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string Department { get; set; } = null!;

    public string Designation { get; set; } = null!;
}
