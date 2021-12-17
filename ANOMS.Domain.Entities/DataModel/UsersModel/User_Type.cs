using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ANOMS.Domain.Entities.DataModel.UsersModel
{
    [Table("User_Type", Schema = "ANOMSBD")]
    public class User_Type
    {
        [Key]
        public int? t_ID { get; set; } = 0;
        public string t_Name { get; set; } = "";
    }
}
