using CPSC440_F2023_Project.Model;
using CPSC440_F2023_Project.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Formats.Asn1.AsnWriter;

namespace CPSC440_F2023_Project.ViewModel
{
    internal class StudentViewModel : BaseViewModel
    {
        public ObservableCollection<KeyValuePair<string, double>> StudentGPAData { get; private set; }
        private static StudentDataHandler SDH;
        public DataTable studentDataTable { get; set; }
        public ICommand ExitCommand { get; private set; }

        public StudentViewModel()
        {
            SDH = new StudentDataHandler();
            StudentGPAData = SDH.StudentGPAData;
            ExitCommand = new RelayCommand(Exit);
        }

        private KeyValuePair<string, double>? _selectedKey = null;
        public KeyValuePair<string, double>? SelectedKey
        {
            get { return _selectedKey; }
            set
            {
                if (StudentGPAData != null && StudentGPAData.Count > 0)
                {
                    _selectedKey = value;
                    OnPropertyChanged(nameof(SelectedKey));
                    StudentID = _selectedKey.GetValueOrDefault().Key;
                    StudentGPA = _selectedKey.GetValueOrDefault().Value;
                    studentDataTable = FetchStudentData(StudentID);
                    OnPropertyChanged(nameof(studentDataTable));
                }

            }
        }
        private string _studentID;
        public string StudentID
        {
            get { return _studentID; }
            set
            {
                _studentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        private double _studentGPA;
        public double StudentGPA
        {
            get { return _studentGPA; }
            set
            {
                _studentGPA = value;
                OnPropertyChanged(nameof(StudentGPA));
            }
        }
        private void Exit(object obj)
        {
            System.Windows.Application.Current.MainWindow.Close();
        }

        public DataTable FetchStudentData(string StudentId)
        {
            var query_data = SDH.GetStudentData(StudentId);
            DataTable dataTable = new DataTable("StudentData");
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("CourseTaken", typeof(string));
            dataTable.Columns.Add("Credit", typeof(int));
            dataTable.Columns.Add("Score", typeof(float));
            dataTable.Columns.Add("ProfessorName", typeof(string));
            foreach (var item in query_data)
            {
                dataTable.Rows.Add(item.Name, item.CourseTaken, item.Credit, item.Score, item.ProfessorName);
            }
            return dataTable;
        }

        public static void UpdateStudentScore(string studentId, string courseId, double score)
        {
            using (var context = new StudentContext())
            {
                var courseHistory = context.CourseHistories.FirstOrDefault(a => a.StudentId == studentId && a.CourseId == courseId);

                if (courseHistory != null)
                {
                    courseHistory.Score = score;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Student or course not found.");
                }
            }
        }
        public static void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                if (dataGrid.DataContext is StudentViewModel viewModel)
                {
                    var editedCellContent = e.EditingElement;
                    var editedRow = (DataRowView)dataGrid.SelectedItem;
                    var cellValue = (editedCellContent as TextBox)?.Text;
                    var studentId = viewModel.StudentID;
                    if (double.TryParse(cellValue, out double parsedScore))
                    {
                        UpdateStudentScore(studentId, editedRow[1].ToString(), parsedScore);
                        SDH.LoadData();
                    }
                }
            }
        }
    }
}
