using AcademyApp.Core.Entities;
using AcademyApp.Core.Repositories;
using AcademyApp.DataAccess.Data;

namespace AcademyApp.DataAccess.Implementations
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AcademyAppDbContext context) : base(context)
        {
        }
    }
}
