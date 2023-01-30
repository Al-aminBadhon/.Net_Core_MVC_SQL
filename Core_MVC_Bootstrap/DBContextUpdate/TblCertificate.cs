using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.Home.DBContextUpdate
{
    public partial class TblCertificate
    {
        public int CertificateId { get; set; }
        public int CerTypeId { get; set; }
        public int UserRoleId { get; set; }
        public int CerNumber { get; set; }
        public string CerName { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Details { get; set; }
        public DateTime? ExpDate { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
