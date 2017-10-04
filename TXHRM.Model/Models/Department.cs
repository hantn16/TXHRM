using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        public bool Status { get; set; }

        //Navigation Properties
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<WorkingProcess> WorkingProcesses { get; set; }
    }
}
