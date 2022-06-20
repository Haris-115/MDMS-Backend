using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Models
{

    public class Stocks
    {
        [Key]
        public int stocks_id { get; set; }
        public int stocks_quantity { get; set; }

        [ForeignKey("medicines_id")]
        public int medicines_id { get; set; }

        [ForeignKey("distributors_id")]
        public int distributors_id { get; set; }
    }
}
