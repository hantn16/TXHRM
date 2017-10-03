using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXHRM.Model.Models
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}