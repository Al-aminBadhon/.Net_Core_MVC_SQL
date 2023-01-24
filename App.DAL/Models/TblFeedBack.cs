using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.DAL.Models
{
    public partial class TblFeedBack
    {
        public int FeedBackId { get; set; }
        public string SenderName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Opinion { get; set; }
        public bool IsDelete { get; set; }
        public bool SeenStatus { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
