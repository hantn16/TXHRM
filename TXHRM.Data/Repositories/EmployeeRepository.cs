using TXHRM.Data.Infrastructure;
using TXHRM.Model.Models;

namespace TXHRM.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}