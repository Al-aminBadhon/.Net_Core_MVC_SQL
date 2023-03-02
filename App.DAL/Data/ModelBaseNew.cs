using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace App.DAL.Data
{
    [Serializable]
    public abstract class ModelBaseNew
    {
        public ModelBaseNew()
        {
            MarkNew();
            
        }

        [NotMapped]
        public bool IsAdd { get; set; }

        [NotMapped]
        public bool IsDelete { get; set; }

        [NotMapped]
        public bool IsOld { get; set; }

        [NotMapped]
        public bool IsRequestSuccess { get; set; } = false;

        [NotMapped]
        public string ERROR_CODE { get; set; }

        [NotMapped]
        public string ERROR_MSG { get; set; }

       

        public void MarkOld()
        {
            IsAdd = false;
            IsDelete = false;
            IsOld = true;
        }
        
        public void MarkNew()
        {
            IsAdd = true;
            IsDelete = false;
            IsOld = false;
        }
    }
}