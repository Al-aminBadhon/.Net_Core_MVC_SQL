using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.DAL.Models
{
    public partial class TblEducationalBackground
    {
        public int EduBackId { get; set; }
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public string DegreeName { get; set; }
        public string InstitutionName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
