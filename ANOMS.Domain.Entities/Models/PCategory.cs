using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class PCategory
    {
        public PCategory()
        {
            Brand = new HashSet<Brand>();
            Inventory = new HashSet<Inventory>();
            PrdtPackage = new HashSet<PrdtPackage>();
            Price = new HashSet<Price>();
            ProductOrder = new HashSet<ProductOrder>();
            Usersd = new HashSet<Usersd>();
        }

        public int PcId { get; set; }
        public string PcName { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Brand> Brand { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<PrdtPackage> PrdtPackage { get; set; }
        public ICollection<Price> Price { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }
        public ICollection<Usersd> Usersd { get; set; }
    }
}
