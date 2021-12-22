using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class Usersd
    {
        public Usersd()
        {
            Brand = new HashSet<Brand>();
            NotificationsNtfnForNavigation = new HashSet<Notifications>();
            NotificationsUserByNavigation = new HashSet<Notifications>();
            PrdtPackage = new HashSet<PrdtPackage>();
            ProductOrder = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public int SId { get; set; }
        public string Name { get; set; }
        public int? TId { get; set; }
        public int? PcId { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int? Active { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string UserBy { get; set; }
        public string SName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }

        public PCategory Pc { get; set; }
        public UserType T { get; set; }
        public ICollection<Brand> Brand { get; set; }
        public ICollection<Notifications> NotificationsNtfnForNavigation { get; set; }
        public ICollection<Notifications> NotificationsUserByNavigation { get; set; }
        public ICollection<PrdtPackage> PrdtPackage { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
