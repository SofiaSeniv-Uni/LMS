namespace UniMVC.Models
{
    public class StudentGrades
    {
        public int StudentId { get; set; }
        public int DisciplineId { get; set; }
        public int Grade {  get; set; } 

        public Student Student { get; set; }
        public Discipline Discipline { get; set; }
    }
}