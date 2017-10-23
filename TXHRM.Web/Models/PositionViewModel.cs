using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TXHRM.Web.Models
{
    public class PositionViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Status { get; set; }

        //Navigation Properties
        public virtual IEnumerable<EmployeeViewModel> Employees { get; set; }

        public virtual IEnumerable<WorkingProcessViewModel> WorkingProcesses { get; set; }
    }
}