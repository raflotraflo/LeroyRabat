using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeroyRabat
{
    public class Award
    {

        public string  description { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string pricePlanCode { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public int? discountToPoints { get; set; }
        public string nameAndValueInfo { get; set; }
    }
}
