using UniMVC.Data;
using UniMVC.Models;
using UniMVC.Repository.Abstract;

namespace UniMVC.Repository.Concrete
{
    public class DisciplineRepository : Repository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(UniDbContext dbContext) : base(dbContext)
        {
        }
    }
}
