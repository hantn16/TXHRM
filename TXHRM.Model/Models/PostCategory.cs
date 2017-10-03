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
        [Display(Name = "Mã chủ đề")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Tên chủ đề")]
        [Required(ErrorMessage = "Hãy nhập tên chủ đề")]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string Alias { get; set; }

        [MaxLength(512)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Thứ tự xuất hiện")]
        [Required(ErrorMessage = "Hãy nhập thứ tự xuất hiện của chủ đề")]
        public int DisplayOrder { get; set; }

        public int ParentID { get; set; }

        public bool? HomeFlag { get; set; }

        [Display(Name = "Ảnh bài viết")]
        [MaxLength(256)]
        public string Image { get; set; }
        //Thuộc tính navigation
        public virtual ICollection<Post> Posts { get; set; }

        [ForeignKey("ParentID")]
        public virtual PostCategory ParentCategory { get; set; }

        public virtual ICollection<PostCategory> ChildCategories { get; set; }
    }
}
