using System;
using System.Collections.Generic;

namespace CPSC440_F2023_Project.Model;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string ProfessorId { get; set; } = null!;

    public int? Credit { get; set; }

    public virtual ICollection<CourseHistory> CourseHistories { get; set; } = new List<CourseHistory>();

    public virtual Professor Professor { get; set; } = null!;
}
