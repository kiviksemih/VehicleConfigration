using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrdersId { get; set; }
        public string ClientMail { get; set; }
        public int? DealerId { get; set; }
        public int? CarsId { get; set; }
        public bool? IsStandartPackage { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public byte? StatusType { get; set; }

        public virtual Cars Cars { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
