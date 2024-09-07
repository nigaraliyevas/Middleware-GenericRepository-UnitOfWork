using AcademyApp.Core.Repositories;
using AcademyApp.DataAccess.Data;

namespace AcademyApp.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AcademyAppDbContext _context;

        public IGroupRepository groupRepository { get; private set; }

        public UnitOfWork(AcademyAppDbContext context)
        {
            _context = context;
            groupRepository = new GroupRepository(_context);
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
