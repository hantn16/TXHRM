using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TXHRM.Web.Models
{
    public class WorkingProcessViewModel
    {

        public long ID { get; set; }

        public long EmployeeID { get; set; }

        public int DepartmentID { get; set; }

        public int PositionID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        //Navigation Properties
        public virtual EmployeeViewModel Employee { get; set; }

        public virtual DepartmentViewModel Department { get; set; }

        public virtual PositionViewModel Position { get; set; }
    }
}