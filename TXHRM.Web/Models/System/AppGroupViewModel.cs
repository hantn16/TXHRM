using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.Web.Models.System
{
    public class AppGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<AppRoleViewModel> Roles { set; get; }
    }
}