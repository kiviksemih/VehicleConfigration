using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleConfiguration.WPF.Helper
{
   public static class StaticOrder
    {
        private static int _CarId { get; set; }

        private static int _PackageTypeId { get; set; }

        public static void SetCarId(int carId)
        {
            _CarId = carId;
        }

        public static int GetCarId()
        {
            return _CarId;
        }


        public static void SetPackageTypeId(int packageTypeId)
        {
            _PackageTypeId = packageTypeId;
        }

        public static int GetPackageTypeId()
        {
            return _PackageTypeId;
        }


    }
}
