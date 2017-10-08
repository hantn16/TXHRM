using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }


        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? DisplayOrder { get; set; }

        public int? ParentID { get; set; }

        public bool? HomeFlag { get; set; }

        public string Image { get; set; }
        //Thuộc tính navigation
        public virtual IEnumerable<PostViewModel> Posts { get; set; }

        public virtual PostCategoryViewModel ParentCategory { get; set; }

        public virtual IEnumerable<PostCategoryViewModel> ChildCategories { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
    }
}