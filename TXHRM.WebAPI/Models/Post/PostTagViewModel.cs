using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TXHRM.WebAPI.Models
{
    public class PostTagViewModel
    {
        public string TagId { get; set; }

        public int PostId { get; set; }

        //Thuộc tính navigation
        public virtual PostViewModel Post { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}