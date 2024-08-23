using Microsoft.EntityFrameworkCore;
using UniMVC.Data;
using UniMVC.Models;
using UniMVC.Repository.Abstract;

namespace UniMVC.Repository.Concrete
{
    public class StudentGradesRepository : Repository<StudentGrades>, IStudentGradesRepository
    {
        public UniDbContext _dbContext;
        public StudentGradesRepository(UniDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentGrades> GetStudentAndDiscipline()
        {
            return _dbContext.StudentGrades.Include(sg => sg.Student).Include(sg => sg.Discipline).ToList();
        }
    }
}
