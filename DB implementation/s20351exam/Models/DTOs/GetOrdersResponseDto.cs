using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Models.DTOs
{
    public class GetOrdersResponseDto
    {
        public DateTime DateOfSubmission { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Employee Employee { get; set; }


    }
}
