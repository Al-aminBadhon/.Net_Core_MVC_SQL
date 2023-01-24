using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.DAL.Models
{
    public partial class TblCompany
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string CompanyDetails { get; set; }
        public bool IsActive { get; set; }
        public bool IsAprroved { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
