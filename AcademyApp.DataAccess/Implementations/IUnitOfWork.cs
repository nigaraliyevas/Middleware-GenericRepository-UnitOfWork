using AcademyApp.Core.Repositories;

namespace AcademyApp.DataAccess.Implementations
{
    public interface IUnitOfWork
    {
        public IGroupRepository groupRepository { get; }
        void Commit();
    }
}
