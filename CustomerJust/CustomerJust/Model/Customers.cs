using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerJust.Model
{
    public class Customers
    {
        public int ID { get; set; } = 0;
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string DistrictName { get; set; }
    }
}
