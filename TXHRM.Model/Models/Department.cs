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
    public class Department : Abstracts.Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }
        
        public int ParentID { get; set; }
        public long LeaderID { get; set; }

        //Navigation Properties
        //[InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual IEnumerable<WorkingProcess> WorkingProcesses { get; set; }
        [ForeignKey("ParentID")]
        public virtual Department ParentDepartment { get; set; }

        [InverseProperty("ParentDepartment")]
        public virtual IEnumerable<Department> ChildDepartments { get; set; }

        [ForeignKey("LeaderID")]
        public virtual Employee Leader { get; set; }
    }
}
