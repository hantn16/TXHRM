using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Model.Abstracts
{
    public interface IAuditable
    {
        bool Status { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }
    }
}
