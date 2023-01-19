using App.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.BLL.Services
{
    public class DirectorsService
    {
        private readonly IHomeRepository _homeRepository;
        public DirectorsService(IHomeRepository homeRepository)
        {
            this._homeRepository = homeRepository;
        }


    }
}
