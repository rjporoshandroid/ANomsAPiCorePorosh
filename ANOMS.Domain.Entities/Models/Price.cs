using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class Price
    {
        public int PcId { get; set; }
        public int PrdtId { get; set; }
        public int BrndId { get; set; }
        public int PkgId { get; set; }
        public double? InPrice { get; set; }
        public double? SellPrice { get; set; }
        public double? PrevPrice { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserBy { get; set; }
        public bool IsDeleted { get; set; }

        public Brand Brnd { get; set; }
        public PCategory Pc { get; set; }
        public PrdtPackage Pkg { get; set; }
        public Product Prdt { get; set; }
    }
}
