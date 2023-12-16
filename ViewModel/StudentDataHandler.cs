using CPSC440_F2023_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CPSC440_F2023_Project.ViewModel
{
    internal class StudentDataHandler
    {
        public ObservableCollection<KeyValuePair<string, double>> StudentGPAData { get; private set; }
        public StudentDataHandler() {
            StudentGPAData = new ObservableCollection<KeyValuePair<string, double>>();
            LoadData();
        }

        private GenericDataService<Info> StudentInfo = new GenericDataService<Info>();

        public void LoadData()
        {

                StudentGPAData.Clear();
                var students = StudentInfo.GetAll();
                foreach (var student in students)
                {
                    List<IStudentCourse> students_data = GetStudentData(student.StudentId);
                    double student_gpa = CalculateStudentGPA.Calculate(students_data);
                    StudentGPAData.Add(new KeyValuePair<string, double>(student.StudentId, student_gpa));
                }
        }


        public List<IStudentCourse> GetStudentData(string StudentId)
        {
            List<IStudentCourse> student_records = new List<IStudentCourse>();
            IQueryable<IStudentCourse> grid_info = (new StudentContext()).CourseHistories
            .Where(a => a.StudentId == StudentId)
            .Include(a => a.Student)
            .Include(a => a.Professor)
            .Include(a => a.Course)
            .Select(a => new StudentCourse
            {
                Name = a.Student.Name,
                CourseTaken = a.Course.CourseId,
                Credit = (int)a.Course.Credit,
                Score = (float)a.Score,
                ProfessorName = a.Professor.Name
            }
            );
            student_records = grid_info.ToList<IStudentCourse>();
            return student_records;
        }
    }
}
