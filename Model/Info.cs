using System;
using System.Collections.Generic;

namespace CPSC440_F2023_Project.Model;

public partial class Info
{
    public string StudentId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<CourseHistory> CourseHistories { get; set; } = new List<CourseHistory>();
}
