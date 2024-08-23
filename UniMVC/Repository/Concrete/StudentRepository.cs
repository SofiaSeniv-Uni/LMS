using Microsoft.EntityFrameworkCore;
using UniMVC.Data;
using UniMVC.Models;
using UniMVC.Repository.Abstract;

namespace UniMVC.Repository.Concrete
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public UniDbContext _dbContext;
        public StudentRepository(UniDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetStudentWithGroup(int studentId)
        {
            var student = _dbContext.Students
            .Include(s => s.Group)
            .FirstOrDefault(m => m.Id == studentId);

            return student;
        }
    }
}
