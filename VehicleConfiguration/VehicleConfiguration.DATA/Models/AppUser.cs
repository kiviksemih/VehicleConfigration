using System;
using System.Collections.Generic;

namespace VehicleConfiguration.DATA.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            Orders = new HashSet<Orders>();
        }

        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
