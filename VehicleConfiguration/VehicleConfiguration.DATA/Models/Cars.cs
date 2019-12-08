using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class Cars
    {
        public Cars()
        {
            Orders = new HashSet<Orders>();
        }

        public int CarsId { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public int Price { get; set; }
        public string CarImagePath { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
