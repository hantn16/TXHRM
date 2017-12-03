using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Data;
using TXHRM.Model.Models;

namespace TXHRM.Identity
{
    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(TXHRMDbContext context) : base(context)
        {
        }
    }
}
