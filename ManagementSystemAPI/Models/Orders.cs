using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.Models
{
    public class Orders
    {
        [Key]
        public int orders_id { get; set; }

        [ForeignKey("distributors_id")]
        public int distributors_id { get; set; }

        [ForeignKey("medstores_id")]
        public int medstores_id { get; set; }
    }
}
