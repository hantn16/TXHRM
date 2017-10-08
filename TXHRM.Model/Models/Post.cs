using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("Post")]
    public class Post : Abstracts.Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [MaxLength(512)]
        [Required]
        public string Name { get; set; }

        [MaxLength(512)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        [StringLength(128)]
        public string Tags { get; set; }

        [ForeignKey("PostCategory")]
        public int CategoryId { get; set; }

        public int ViewCount { get; set; }

        //Thuộc tính Navigation
        public virtual PostCategory PostCategory { get; set; }

        public IEnumerable<PostTag> PostTags { get; set; }
    }
}
