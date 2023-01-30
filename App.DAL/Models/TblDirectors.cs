using App.DAL.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.DAL.Models
{
    public partial class TblDirectors : ModelBase<TblDirectors>
    {
        public int DirectorId { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]

        public string Designation { get; set; }
        [Required]

        public string CompanyPost { get; set; }
        public string Image { get; set; }
        public string Details { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        [NotMapped]
        public IFormFile PhotoUpload { get; set; }
    }
}
