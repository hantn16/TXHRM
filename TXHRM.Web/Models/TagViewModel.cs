using System.Collections.Generic;

namespace TXHRM.Web.Models
{
    public class TagViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        //Thuộc tính navigation
        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }
    }
}