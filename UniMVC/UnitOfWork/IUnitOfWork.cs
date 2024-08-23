using UniMVC.Repository.Abstract;
using UniMVC.Repository.Concrete;

namespace UniMVC.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepository Student {  get; }
        ITeacherRepository Teacher { get; }
        IGroupRepository Group { get; }
        IDisciplineRepository Discipline { get; }
        IStudentGradesRepository StudentGrades { get; }
        void Save();
    }
}
