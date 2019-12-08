using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class VehicleFeaturesType
    {
        public VehicleFeaturesType()
        {
            VehicleFeatures = new HashSet<VehicleFeatures>();
        }

        public int VehicleFeaturesTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<VehicleFeatures> VehicleFeatures { get; set; }
    }
}
