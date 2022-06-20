using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.Models
{
    public class Medstores
    {
        [Key]
        public int medstores_id { get; set; }
        public string medstores_name { get; set; }
        public int medstores_number { get; set; }
        public string medstores_lisence { get; set; }
        public string medstores_address { get; set; }

        [ForeignKey("users_id")]
        public int users_id { get; set; }
    }
}
