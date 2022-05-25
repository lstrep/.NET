using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models
{
    public class Confectionery
    {
        public int IdConfectionery { get; set; }
        public string Name { get; set; }
        public float PricePerOne { get; set; }

        public virtual ICollection<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; } = new HashSet<Confectionery_ClientOrder>();
    }
}
