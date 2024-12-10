namespace WebApplication1.Models
{
    public class GradeViewModel
    {
        public List<Subject> Subjects { get; set; }

        public GradeViewModel()
        {
            Subjects = new List<Subject>
            {
                new Subject { Name = "J. Polski", Grades = new List<double>() },
                new Subject { Name = "J. Angielski", Grades = new List<double>() },
                new Subject { Name = "Matematyka", Grades = new List<double>() },
                new Subject { Name = "Historia", Grades = new List<double>() },
                new Subject { Name = "WF", Grades = new List<double>() },
                new Subject { Name = "Geografia", Grades = new List<double>() },
                new Subject { Name = "Biologia", Grades = new List<double>() }
            };
        }

        public void AddGrade(string subjectName, double grade)
        {
            var subject = Subjects.FirstOrDefault(s => s.Name == subjectName);
            if (subject != null && grade >= 1 && grade <= 6)
            {
                subject.Grades.Add(grade);
            }
        }

        public void AddSubject(string newSubjectName)
        {
            if (!string.IsNullOrWhiteSpace(newSubjectName) && !Subjects.Any(s => s.Name == newSubjectName))
            {
                Subjects.Add(new Subject { Name = newSubjectName, Grades = new List<double>() });
            }
        }
    }

    public class Subject
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average => Grades.Any() ? Grades.Average() : 0.0;
    }
}