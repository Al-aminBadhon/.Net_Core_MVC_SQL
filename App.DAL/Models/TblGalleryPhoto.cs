using App.DAL.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.DAL.Models
{
    public partial class TblGalleryPhoto : ModelBase<TblGalleryPhoto>
    {
        public int ImageId { get; set; }
        
        public string Name { get; set; }
      
        public string Image { get; set; }
        public string Flag { get; set; }
        public bool IsDelete { get; set; }
        public string Details { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        [NotMapped]
        public IFormFile PhotoUpload { get; set; }
    }
}
