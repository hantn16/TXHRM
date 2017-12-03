using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Models
{
    [Table("PostCategory")]
    public class PostCategory : Abstracts.Auditable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [Index(IsUnique =true)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string Alias { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public int? DisplayOrder { get; set; }

        public int? ParentId { get; set; }

        public bool? HomeFlag { get; set; }

        //Thuộc tính navigation
        public virtual IEnumerable<Post> Posts { get; set; }

        [ForeignKey("ParentId")]
        public virtual PostCategory ParentCategory { get; set; }

        [InverseProperty("ParentCategory")]
        public virtual IEnumerable<PostCategory> ChildCategories { get; set; }
    }
}
