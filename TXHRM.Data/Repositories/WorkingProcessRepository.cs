using TXHRM.Data.Infrastructure;
using TXHRM.Model.Models;

namespace TXHRM.Data.Repositories
{
    public interface IWorkingProcessRepository : IRepository<WorkingProcess>
    {
    }

    public class WorkingProcessRepository : RepositoryBase<WorkingProcess>, IWorkingProcessRepository
    {
        public WorkingProcessRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}