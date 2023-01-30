using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.Home.DBContextUpdate
{
    public partial class TblLoginHistory
    {
        public int LogHisId { get; set; }
        public int UserId { get; set; }
        public DateTime LastLoginTime { get; set; }

        public virtual TblUser User { get; set; }
    }
}
