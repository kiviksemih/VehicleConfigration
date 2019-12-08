using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class Dealer
    {
        public Dealer()
        {
            Orders = new HashSet<Orders>();
        }

        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerEmail { get; set; }
        public string DealerPhone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
