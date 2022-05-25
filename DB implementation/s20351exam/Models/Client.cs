using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new HashSet<ClientOrder>();
    }
}
