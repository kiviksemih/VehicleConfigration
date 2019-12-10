using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleConfiguration.DATA.Models;
using VehicleConfiguration.WPF.Helper;

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

        public Cars GetCarById(int carId)
        {
            return db.Cars.Where(s => s.IsActive && !s.IsDeleted&&s.CarsId==carId).SingleOrDefault();
        }


        public List<Cars> GetAllActiveCars()
        {
            return db.Cars.Where(s => s.IsActive && !s.IsDeleted).ToList();
        }

        public List<VehicleFeatures> GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(int packageType, VehicleFeaturesTypeList vehicleFeaturesType)
        {
            bool packageBoolType = false;
            if (packageType == 0)
            {
                packageBoolType = true;
            }
            return db.VehicleFeatures.Where(s => s.IsActive && !s.IsDeleted && s.IsStandartPackage == packageBoolType && s.VehicleFeaturesTypeId == (int)vehicleFeaturesType).ToList();
        }

        public void InsertOrders(Orders insertOrder)
        {
            db.Orders.Add(insertOrder);
            db.SaveChanges();
        }
    }
}
