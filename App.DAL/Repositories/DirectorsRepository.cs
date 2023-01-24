using App.DAL.Data;
using App.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DAL.Repositories
{
    public class DirectorsRepository :IDirectorsRepository
    {
        private readonly MHDBContext _mHDBContext;
        public DirectorsRepository(MHDBContext mHDBContext)
        {
            _mHDBContext = mHDBContext;
        }

    }
}
