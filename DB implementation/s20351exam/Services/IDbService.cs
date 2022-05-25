using s20351Retake.Models;
using s20351Retake.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Services
{
    public interface IDbService
    {
        public Task<List<GetOrdersResponseDto>> GetOrder();
        public Task<ClientOrder> AddOrder(AddOrderRequestDto order);
    }
}
