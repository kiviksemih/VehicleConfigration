using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int? OrderId { get; set; }
        public int? VehicleFeaturesId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Orders Order { get; set; }
    }
}
