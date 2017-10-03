using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        [ForeignKey("MenuGroup")]
        public int GroupID { get; set; }

        public string Target { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual MenuGroup MenuGroup { get; set; }
    }
}
