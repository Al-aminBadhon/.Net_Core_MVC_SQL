using System;
using System.Collections.Generic;

namespace App.DAL.Models
{
    public partial class TblUserRole
    {
        public TblUserRole()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
