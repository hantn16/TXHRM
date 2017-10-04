using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("WorkingProcess")]
    public class WorkingProcess
    {
        [Key]
        public long ID { get; set; }

        public long EmployeeID { get; set; }

        public int DepartmentID { get; set; }

        public int PositionID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //Navigation Properties
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [ForeignKey("PositionID")]
        public virtual Position Position { get; set; }

    }
}
