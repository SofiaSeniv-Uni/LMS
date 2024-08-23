using UniMVC.Models;

namespace UniMVC.Repository.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentWithGroup(int studentId);
    }
}
