using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.Home.DBContextUpdate
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblLoginHistory = new HashSet<TblLoginHistory>();
        }

        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirmed { get; set; }
        public bool? IsDisabled { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual TblUserRole UserRole { get; set; }
        public virtual ICollection<TblLoginHistory> TblLoginHistory { get; set; }
    }
}
