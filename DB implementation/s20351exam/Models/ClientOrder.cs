using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models
{
    public class ClientOrder
    {

        public int IdClientOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Comments { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }


        public virtual ICollection<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; } = new HashSet<Confectionery_ClientOrder>();
    }
}
