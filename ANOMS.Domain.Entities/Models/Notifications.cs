using System;
using System.Collections.Generic;

namespace ANOMS.Domain.Entities.Models
{
    public partial class Notifications
    {
        public int NtfnId { get; set; }
        public int NId { get; set; }
        public string NMsg { get; set; }
        public string MsgBang { get; set; }
        public DateTime? NtfnDateMsg { get; set; }
        public DateTime? Validity { get; set; }
        public int NtfnFor { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserBy { get; set; }
        public bool? IsDeleted { get; set; }

        public NCategory N { get; set; }
        public Usersd NtfnForNavigation { get; set; }
        public Usersd UserByNavigation { get; set; }
    }
}
