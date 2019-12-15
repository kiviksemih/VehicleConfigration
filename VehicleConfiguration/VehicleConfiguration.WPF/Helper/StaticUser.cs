using System;
using System.Collections.Generic;
using System.Text;
using VehicleConfiguration.DATA.Models;

namespace VehicleConfiguration.WPF.Helper
{
    public static class StaticUser
    {
        private static AppUser _AppUser { get; set; }


        public static void SetUser(AppUser entity)
        {
            _AppUser = entity;
        }

        public static AppUser GetUser()
        {
            return _AppUser;
        }

        public static void Logout()
        {
            _AppUser = null;
        }
    }
}
