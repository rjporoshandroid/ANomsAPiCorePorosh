using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ANOMS.Domain.Entities.DataModel.UsersModel
{
    [Table("UserDetails", Schema = "ANOMSBD")]
    public class UserDetails
    {
        public int s_ID { get; set; } = 0;
        public int id { get; set; } = 0;
        public string enrollFrom { get; set; } = "";
        public int total_Time_Ordered { get; set; } = 0;
        public float total_Around_Order { get; set; } = 0;
        public string due_Status { get; set; } = "";
        public DateTime entryDate { get; set; } = DateTime.Now;
        public DateTime modifyDate { get; set; } = DateTime.Now;
        public string userBy { get; set; } = "";


    }
}
