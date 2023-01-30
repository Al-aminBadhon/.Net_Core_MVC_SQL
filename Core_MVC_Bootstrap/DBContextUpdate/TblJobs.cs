using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.Home.DBContextUpdate
{
    public partial class TblJobs
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int UserRoleId { get; set; }
        public int CompanyId { get; set; }
        public string JobLevel { get; set; }
        public string Salary { get; set; }
        public string Experience { get; set; }
        public string JobType { get; set; }
        public DateTime? DeadLine { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public string JobDetails { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
