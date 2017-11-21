using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Data.Infrastructure;
using TXHRM.Model.Models;

namespace TXHRM.Data.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        List<Permission> GetByUserId(string userId);
    }
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory) :base(dbFactory)
        {
        }

        public List<Permission> GetByUserId(string userId)
        {
            try
            {
                //var query = from f in DbContext.Functions
                //            join p in DbContext.Permissions on f.ID equals p.FunctionId
                //            join r in DbContext.AppRoles on p.RoleId equals r.Id
                //            join ur in DbContext.AppUserRoles on r.Id equals ur.RoleId
                //            join u in DbContext.Users on ur.UserId equals u.Id
                //            where u.Id == userId
                //            select p;
                List<Permission> query = DbContext.Permissions.Join(DbContext.AppRoles, per => per.RoleId, role => role.Id, (per, role) => new { per, role.Id })
                    .Join(DbContext.AppUserRoles, e => e.Id, userRole => userRole.RoleId, (e, userRole) => new { e.per, userRole.UserId }).Where(g => g.UserId == userId).Select(c => c.per).ToList();
                return query;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
