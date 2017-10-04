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
        public int ID { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên chủ đề")]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string Alias { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hãy nhập thứ tự xuất hiện của chủ đề")]
        public int DisplayOrder { get; set; }

        public int ParentID { get; set; }

        public bool? HomeFlag { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }
        //Thuộc tính navigation
        public virtual ICollection<Post> Posts { get; set; }

        [ForeignKey("ParentID")]
        public virtual PostCategory ParentCategory { get; set; }

        public virtual ICollection<PostCategory> ChildCategories { get; set; }
    }
}
