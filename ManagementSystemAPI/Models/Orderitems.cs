using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Models
{
    public class Orderitems
    {
        [Key]
        public int orderitems_id { get; set; }
        public int orderitems_quantity { get; set; }

        [ForeignKey("orders_id")]
        public int orders_id { get; set; }

        [ForeignKey("medicines_id")]
        public int medicines_id { get; set; }
    }
}
