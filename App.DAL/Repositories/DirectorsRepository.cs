using App.DAL.Data;
using App.DAL.Models;
using App.DAL.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class DirectorsRepository/*<TModel>*/ :IDirectorsRepository/*<TModel> where TModel : class*/
    {
        private readonly MHDBContext _mHDBContext;
        public DirectorsRepository(MHDBContext mHDBContext)
        {
            _mHDBContext = mHDBContext;
        }

        public async Task<List<TblDirectors>> GetAllDirectors()
        {
            try
            { 
                List<TblDirectors> directors = new List<TblDirectors>();
                directors = await _mHDBContext.TblDirectors.ToListAsync(); 
                return directors;
            }
            catch
            {
                throw;
            }
           
        }

    }
}
