using UniMVC.Data;
using UniMVC.Repository.Abstract;
using UniMVC.Repository.Concrete;

namespace UniMVC.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private UniDbContext _dbContext;
        public IStudentRepository Student { get; private set; }

        public ITeacherRepository Teacher { get; private set; }

        public IGroupRepository Group { get; private set; }

        public IDisciplineRepository Discipline { get; private set; }

        public IStudentGradesRepository StudentGrades { get; private set; }

        public UnitOfWork(UniDbContext dbContext)
        {
            _dbContext = dbContext;
            Student = new StudentRepository(_dbContext);
            Teacher = new TeacherRepository(_dbContext);
            Group = new GroupRepository(_dbContext);
            Discipline = new DisciplineRepository(_dbContext);
            StudentGrades = new StudentGradesRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
