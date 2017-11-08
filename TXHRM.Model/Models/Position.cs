using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("Position")]
    public class Position : Abstracts.Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Alias { get; set; }
        //Navigation Properties
        [InverseProperty("Position")]
        public virtual ICollection<Employee> Employees { get; set; }

        [InverseProperty("Position")]
        public virtual ICollection<WorkingProcess> WorkingProcesses { get; set; }
    }
}
