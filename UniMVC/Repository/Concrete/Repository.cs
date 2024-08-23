using Microsoft.EntityFrameworkCore;
using UniMVC.Data;
using UniMVC.Repository.Abstract;

namespace UniMVC.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UniDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(UniDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            //_dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            //_dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            //_dbContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
            //_dbContext.SaveChanges();
        }
    }
}
