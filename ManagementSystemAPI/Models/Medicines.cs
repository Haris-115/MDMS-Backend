using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystemAPI.Models
{
    public class Medicines
    {
        [Key]
        public int medicines_id { get; set; }
        public string medicines_name { get; set; }
        public string molecule { get; set; }
        public int price { get; set; }
        public string batch_no { get; set; }
        //public DateTime manufacture_date { get; set; }
        //public DateTime expiry_date { get; set; }

        [ForeignKey("manufactures_id")]
        public int manufactures_id { get; set; }
    }
}
