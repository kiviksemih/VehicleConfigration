using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleConfiguration.DATA.Models;

namespace VehicleConfiguration.WPF.Operations
{
   public class GeneralOperation
    {
        VehicleConfiguratorContext db;

        public GeneralOperation()
        {
            db = new VehicleConfiguratorContext();
        }

        public AppUser GetLoginUser(string username, string password)
        {
            return db.AppUser.Where(s => s.Username == username && s.Password == password && s.IsActive && !s.IsDeleted).SingleOrDefault();
        }
    }
}
