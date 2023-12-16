using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC440_F2023_Project.Model
{
    internal interface IStudentCourse
    {
        string Name { get; set; }
        string CourseTaken { get; set; }
        int Credit { get; set; }
        float Score { get; set; }
        string ProfessorName { get; set; }
    }
}
