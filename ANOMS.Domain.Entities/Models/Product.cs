using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            PrdtPackage = new HashSet<PrdtPackage>();
            Price = new HashSet<Price>();
            ProductOrder = new HashSet<ProductOrder>();
        }

        public int PrdtId { get; set; }
        public int? PcId { get; set; }
        public string PrdtName { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Product Prdt { get; set; }
        public Product InversePrdt { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<PrdtPackage> PrdtPackage { get; set; }
        public ICollection<Price> Price { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
