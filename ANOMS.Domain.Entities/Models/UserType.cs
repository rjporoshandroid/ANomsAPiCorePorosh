using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Usersd = new HashSet<Usersd>();
        }

        public int TId { get; set; }
        public string TName { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Usersd> Usersd { get; set; }
    }
}
