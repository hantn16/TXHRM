using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TXHRM.Web.Models.Employee
{
    public class PositionViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        //Navigation Properties
        public virtual IEnumerable<EmployeeViewModel> Employees { get; set; }

        public virtual IEnumerable<WorkingProcessViewModel> WorkingProcesses { get; set; }
    }
}