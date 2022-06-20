using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.Models
{
    public class OrderDetails
    {
        public int quantity { get; set; }
        public string medicines_name { get; set; }
        public int medicines_price { get; set; }
        [ForeignKey("orderitems_id")]
        public int orderitems_id { get; set; }
        [ForeignKey("orders_id")]
        public int orders_id { get; set; }
    }
}
