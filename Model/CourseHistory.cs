using System;
using System.Collections.Generic;

namespace CPSC440_F2023_Project.Model;

public partial class CourseHistory
{
    public string StudentId { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public string ProfessorId { get; set; } = null!;

    public double Score { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Professor Professor { get; set; } = null!;

    public virtual Info Student { get; set; } = null!;
}
