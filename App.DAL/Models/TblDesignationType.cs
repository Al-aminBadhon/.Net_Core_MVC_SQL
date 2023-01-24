using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.DAL.Models
{
    public partial class TblDesignationType
    {
        public TblDesignationType()
        {
            TblDesignation = new HashSet<TblDesignation>();
        }

        public int DesigTypeId { get; set; }
        public string DesigName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<TblDesignation> TblDesignation { get; set; }
    }
}
