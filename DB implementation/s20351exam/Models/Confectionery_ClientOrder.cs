using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models
{
    public class Confectionery_ClientOrder
    {

        public int IdClientOrder { get; set; }
        public ClientOrder ClientOrder { get; set; }
        public int IdConfectionery { get; set; }
        public Confectionery Confectionery { get; set; }
        public int Amount { get; set; }
        public string Comments { get; set; }
    }
}
