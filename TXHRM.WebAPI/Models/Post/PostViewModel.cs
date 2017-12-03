using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.WebAPI.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public string Tags { get; set; }

        public int CategoryId { get; set; }

        public int ViewCount { get; set; }



        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }


        //Thuộc tính Navigation
        public virtual PostCategoryViewModel PostCategory { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }
    }
}