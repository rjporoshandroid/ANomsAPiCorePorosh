using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class PrdtPackage
    {
        public PrdtPackage()
        {
            Inventory = new HashSet<Inventory>();
            Price = new HashSet<Price>();
            ProductOrder = new HashSet<ProductOrder>();
        }

        public int PkgId { get; set; }
        public int PrdtId { get; set; }
        public int PcId { get; set; }
        public int BrndId { get; set; }
        public string PkgName { get; set; }
        public string PkgGrade { get; set; }
        public int? MinQuantity { get; set; }
        public int? ImageId { get; set; }
        public string ImageBution { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Brand Brnd { get; set; }
        public PCategory Pc { get; set; }
        public Product Prdt { get; set; }
        public Usersd UserByNavigation { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<Price> Price { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
