using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("PostTag")]
    public class PostTag
    {
        [Key]
        [Column(TypeName = "varchar",Order =1)]
        [MaxLength(50)]
        public string TagId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PostId { get; set; }

        //Thuộc tính navigation
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
