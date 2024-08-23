using Microsoft.EntityFrameworkCore;
using UniMVC.Data;
using UniMVC.Models;
using UniMVC.Repository.Abstract;

namespace UniMVC.Repository.Concrete
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly UniDbContext _dbContext;
        public GroupRepository(UniDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Group GetGroupWithStudents(int groupId)
        {
            var group = _dbContext.Groups
            .Include(g => g.Students)
            .FirstOrDefault(m => m.Id == groupId);

            return group;
        }
    }
}
