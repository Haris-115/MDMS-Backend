using RTools_NTS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystemAPI.Models
{
    public class UserDetails : Users
    {
        public string name { get; set; }
        public string lisence { get; set; }
        public string address { get; set; }
        public int number { get; set; }
    }
}
