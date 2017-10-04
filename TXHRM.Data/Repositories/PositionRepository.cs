using TXHRM.Data.Infrastructure;
using TXHRM.Model.Models;

namespace TXHRM.Data.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
    }

    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}