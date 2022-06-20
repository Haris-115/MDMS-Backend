using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.Models
{
    public class StockDetails
    {
        public int medicines_id { get; set; }
        public string medicines_name { get; set; }
        public string molecule { get; set; }
        public int price { get; set; }
        public string batch_no { get; set; }
    }
}