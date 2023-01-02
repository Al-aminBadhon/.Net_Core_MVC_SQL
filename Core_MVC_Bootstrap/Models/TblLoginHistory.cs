using System;
using System.Collections.Generic;

namespace App.Home.Models
{
    public partial class TblLoginHistory
    {
        public int LogHisId { get; set; }
        public int UserId { get; set; }
        public DateTime LastLoginTime { get; set; }

        public virtual TblUser User { get; set; }
    }
}
