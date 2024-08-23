using UniMVC.Models;

namespace UniMVC.Repository.Abstract
{
    public interface IGroupRepository : IRepository<Group>
    {
        Group GetGroupWithStudents(int groupId);
    }
}
