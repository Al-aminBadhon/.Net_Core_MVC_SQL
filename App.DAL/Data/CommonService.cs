using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DAL.Data
{
    public static class CommonService
    {
        public static dynamic SetCommonFields(dynamic model)
        {
            if(model.isAdd)
            {
                model.IsDelete = false;
                model.CreatedBy = 1;
                model.CreatedDate = DateTime.Now;
                model.UpdatedBy = null;
                model.UpdatedDate = null;
            }
            else
            {
                model.IsDelete = false;
                model.CreatedBy = null;
                model.CreatedDate = null;
                model.UpdatedBy = 1;
                model.UpdatedDate = DateTime.Now;
            }
            return model;
        }
    }
}
