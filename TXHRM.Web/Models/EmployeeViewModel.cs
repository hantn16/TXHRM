using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.Web.Models
{
    public class EmployeeViewModel
    {

        public long ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string IDCardNo { get; set; }
        public DateTime DateIssued { get; set; }
        public string PlaceIssued { get; set; }

        public DateTime JoinDate { get; set; }

        public int DepartmentID { get; set; }

        public long LeaderID { get; set; }

        public int PositionID { get; set; }

        //Navigation Properties
        public virtual IEnumerable<WorkingProcessViewModel> WorkingProcesses { get; set; }

        public virtual PositionViewModel Position { get; set; }

        public virtual EmployeeViewModel Leader { get; set; }

        public virtual DepartmentViewModel Department { get; set; }
    }
}