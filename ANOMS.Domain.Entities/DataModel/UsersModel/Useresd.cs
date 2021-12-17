using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ANOMS.Domain.Entities.DataModel.UsersModel
{
    [Table("Usersd", Schema = "ANOMSBD")]
    public class Useresd
    {
        [Key]
        public int id { get; set; } = 0;
        public int s_ID { get; set; } = 0;
        public string name { get; set; } = "";
        public int? t_ID { get; set; } = 0;
        public int? pc_ID { get; set; } = 0;
        public string contact { get; set; } = "";
        public string address { get; set; } = "";
        public int? active { get; set; } = 0;
        public DateTime entryDate { get; set; } = DateTime.Now;
        public DateTime modifyDate { get; set; } = DateTime.Now;
        public string userBy { get; set; } = "porosh";
        public string s_Name { get; set; } = "";
        public string password { get; set; } = "";
        public string email { get; set; } = "";
    }
}
