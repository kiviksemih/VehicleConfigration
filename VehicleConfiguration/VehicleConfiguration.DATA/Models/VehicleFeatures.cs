using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class VehicleFeatures
    {
        public int VehicleFeaturesId { get; set; }
        public string FeaturesName { get; set; }
        public int FeaturesPrice { get; set; }
        public bool? IsStandartPackage { get; set; }
        public int VehicleFeaturesTypeId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual VehicleFeaturesType VehicleFeaturesType { get; set; }
    }
}
