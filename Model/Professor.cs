using System;
using System.Collections.Generic;

namespace CPSC440_F2023_Project.Model;

public partial class Professor
{
    public string ProfessorId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CourseHistory> CourseHistories { get; set; } = new List<CourseHistory>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
