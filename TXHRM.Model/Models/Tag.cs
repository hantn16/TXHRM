using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXHRM.Model.Models
{
    [Table("Tag")]
    public class Tag : Abstracts.Auditable
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        //Thuộc tính navigation
        public virtual IEnumerable<PostTag> PostTags { get; set; }
    }
}