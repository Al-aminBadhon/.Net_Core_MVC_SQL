using System;
using System.Collections.Generic;
using System.Text;
using App.DAL.Data;
using App.DAL.RepositoryContracts;

namespace App.DAL.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly MHDBContext _mHDBcontext;

        public HomeRepository(MHDBContext mHDBContext)
        {
            _mHDBcontext = mHDBContext;
        }

    }
}
