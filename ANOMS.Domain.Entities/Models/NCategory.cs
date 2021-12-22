using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class NCategory
    {
        public NCategory()
        {
            Notifications = new HashSet<Notifications>();
        }

        public int NId { get; set; }
        public string NType { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Notifications> Notifications { get; set; }
    }
}
