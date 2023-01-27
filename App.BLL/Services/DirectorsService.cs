using App.BLL.ServiceContracts;
using App.DAL.Models;
using App.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class DirectorsService : IDirectorsService
    {
        private readonly IDirectorsRepository _directorsRepository;
        public DirectorsService(IDirectorsRepository directorsRepository)
        {
            this._directorsRepository = directorsRepository;
        }

        public async Task<List<TblDirectors>> GetAllDirectors()
        {
            return await _directorsRepository.GetAllDirectors();
        }
    }
}
