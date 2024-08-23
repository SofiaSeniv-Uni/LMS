using UniMVC.Models;

namespace UniMVC.Repository.Abstract
{
    public interface IStudentGradesRepository : IRepository<StudentGrades>
    {
        List<StudentGrades> GetStudentAndDiscipline();
    }
}
