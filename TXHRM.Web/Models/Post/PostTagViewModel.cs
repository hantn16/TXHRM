using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TXHRM.Web.Models.Common;

namespace TXHRM.Web.Models.Post
{
    public class PostTagViewModel
    {

        public string TagID { get; set; }

        public int PostID { get; set; }

        //Thuộc tính navigation
        public virtual PostViewModel Post { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}