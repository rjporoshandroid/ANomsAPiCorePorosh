using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class UserDetails
    {
        public int SId { get; set; }
        public int Id { get; set; }
        public string EnrollFrom { get; set; }
        public int? TotalTimeOrdered { get; set; }
        public double? TotalAroundOrder { get; set; }
        public string DueStatus { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
