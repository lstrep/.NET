using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models.DTOs
{
    public class AddOrderRequestDto
    {
        public List<Confectionery_ClientOrder> confectionery_ClientOrders { get; set; }
        public string Comments { get; set; }
        public Client Client { get; set; }

    }
}
