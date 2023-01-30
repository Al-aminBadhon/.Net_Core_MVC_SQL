using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.Home.DBContextUpdate
{
    public partial class TblDesignation
    {
        public int DesigId { get; set; }
        public string DesigName { get; set; }
        public int DesigTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string Details { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual TblDesignationType DesigType { get; set; }
    }
}
