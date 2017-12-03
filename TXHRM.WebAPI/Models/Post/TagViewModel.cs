using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.WebAPI.Models
{
    public class TagViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        //Thuộc tính navigation
        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }
    }
}