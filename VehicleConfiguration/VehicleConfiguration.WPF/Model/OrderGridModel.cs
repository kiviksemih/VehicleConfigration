using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VehicleConfiguration.WPF.Model
{
   public class OrderGridModel
    {
        [DisplayName("Sipariş Numarası")]
        public int OrderId { get; set; }

        [DisplayName("Sipariş Veren Kullanıcı")]
        public string UserName { get; set; }

        [DisplayName("Araç Modeli")]
        public string CarName { get; set; }

        [DisplayName("Araç Paketi")]
        public string PackageTypeName { get; set; }

        [DisplayName("Bayi")]
        public string DeallerName { get; set; }

        [DisplayName("Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }


    }
}
