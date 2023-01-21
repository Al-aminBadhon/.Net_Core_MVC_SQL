using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.DAL.Models
{
    public partial class TblDirectors
    {
        public int DirectorId { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]

        public string Designation { get; set; }
        [Required]

        public string CompanyPost { get; set; }
        public byte[] Image { get; set; }
        public string Details { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
