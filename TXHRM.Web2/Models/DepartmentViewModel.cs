using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.Web2.Models
{
    public class DepartmentViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public bool Status { get; set; }

        //Navigation Properties
        public virtual IEnumerable<EmployeeViewModel> Employees { get; set; }

        public virtual IEnumerable<WorkingProcessViewModel> WorkingProcesses { get; set; }
    }
}