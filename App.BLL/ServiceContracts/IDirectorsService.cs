using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.ServiceContracts
{
    public interface IDirectorsService
    {
        Task<List<TblDirectors>> GetAllDirectors();
        Task<TblDirectors> CreateDirectors(TblDirectors tblDirectors);
        Task<TblDirectors> UpdateDirectors(TblDirectors tblDirectors);
    }
}
