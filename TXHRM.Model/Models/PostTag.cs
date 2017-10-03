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
        public int TagID { get; set; }

        [Key]
        public int PostID { get; set; }

        //Thuộc tính navigation
        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}
