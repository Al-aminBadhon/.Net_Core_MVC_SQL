using App.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DAL.Utilities
{
   
    public partial class AppUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public AppUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
       

        public string UserName
        {
            get
            {
                return (string)_session.GetString("UserName");

            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetString("UserName", value); ;
            }
        }
        public string UserFirstName
        {
            get
            {
                return (string)_session.GetString("UserFirstName");

            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetString("UserFirstName", value); ;
            }
        }
        public int UserRoleID
        {
            get
            {
                return (int)_session.GetInt32("UserRoleID");
                //return HttpContext.Session.GetString("UserName");

            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("UserRoleID", value); ;
            }
        }
        public int UserID
        {
            get
            {
                return (int)_session.GetInt32("UserID");
                //return HttpContext.Session.GetString("UserName");

            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("UserID", value); ;
            }
        }
    }
}
