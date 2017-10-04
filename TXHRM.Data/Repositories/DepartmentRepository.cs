using TXHRM.Data.Infrastructure;
using TXHRM.Model.Models;

namespace TXHRM.Data.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
    }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}