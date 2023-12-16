using CPSC440_F2023_Project.Model;
using System.Collections.Generic;

namespace CPSC440_F2023_Project.ViewModel
{
    internal class CalculateStudentGPA
    {
        public static float Calculate(List<IStudentCourse> studentData)
        {
            float total_gpa = 0;
            int total_credits = 0;
            foreach (IStudentCourse record in studentData)
            {
                if (record != null)  //Some students only take 1 class. Those records are null
                {
                    total_gpa += ConvertScoreToGrade(((StudentCourse)record).Score) * ((StudentCourse)record).Credit;
                    total_credits += ((StudentCourse)record).Credit;
                }
            }
            return total_gpa / total_credits;
        }

        public static float ConvertScoreToGrade(float score)
        {
            if (score >= 94)
            {
                return 4.0f;
            }
            else if (score >= 90)
            {
                return 3.7f;
            }
            else if (score >= 87)
            {
                return 3.3f;
            }
            else if (score >= 84)
            {
                return 3.0f;
            }
            else if (score >= 80)
            {
                return 2.7f;
            }
            else if (score >= 77)
            {
                return 2.3f;
            }
            else if (score >= 74)
            {
                return 2.0f;
            }
            else if (score >= 70)
            {
                return 1.7f;
            }
            else if (score >= 67)
            {
                return 1.3f;
            }
            else if (score >= 64)
            {
                return 1.0f;
            }
            else if (score >= 60)
            {
                return 0.7f;
            }
            else
            {
                return 0.0f;
            }
        }

    }
}
