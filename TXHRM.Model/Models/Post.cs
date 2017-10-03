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

        [Display(Name = "Tiêu đề")]
        [MaxLength(512)]
        [Required(ErrorMessage = "Hãy nhập tiêu đề bài viết")]
        public string Name { get; set; }

        [MaxLength(512)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [Display(Name = "Nội dung bài viết")]
        [Required(ErrorMessage = "Hãy nhập nội dung")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [MaxLength(512)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ảnh bài viết")]
        [MaxLength(256)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        [Display(Name = "Thẻ tìm kiếm")]
        [StringLength(128)]
        public string Tags { get; set; }

        [Display(Name = "Mã chủ đề")]
        [ForeignKey("PostCategory")]
        public int CategoryId { get; set; }

        [Display(Name = "Số lần xem")]
        public int ViewCount { get; set; }

        //Thuộc tính Navigation
        public virtual PostCategory PostCategory { get; set; }
    }
}
