using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CPSC440_F2023_Project.Model
{
    internal class StudentCourse: IStudentCourse
    {
        public string Name { get; set; }
        public string CourseTaken { get; set; }
        public int Credit { get; set; }
        public float Score { get; set; }
        public string ProfessorName { get; set; }
    }
}
