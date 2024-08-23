using UniMVC.Data;
using UniMVC.Models;
using UniMVC.Repository.Abstract;

namespace UniMVC.Repository.Concrete
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(UniDbContext dbContext) : base(dbContext)
        {
        }
    }
}
