using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXHRM.Model.Abstracts;

namespace TXHRM.Model.Models
{
    [Table("Menu")]
    public class Menu : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        [ForeignKey("MenuGroup")]
        public int GroupId { get; set; }

        public string Target { get; set; }

        public virtual MenuGroup MenuGroup { get; set; }
    }
}
