using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeroyRabat
{
    public class Card
    {
        public string cardNumber { get; set; }
        public bool validCardNumber { get; set; }
        public bool error { get; set; }
        public bool rechargePossible { get; set; }
        public string accountStatus { get; set; }
        public string cardStatus { get; set; }
        public int? pointBalance { get; set; }
        public string program { get; set; }
        public string calculatedPoints { get; set; }
        
        public List<Award> awards { get; set; }

        public bool needResetRabateAlert { get; set; }
        public string message { get; set; }
    }
}
