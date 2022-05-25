using Microsoft.EntityFrameworkCore;
using s20351Retake.Models;
using s20351Retake.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Services
{
    public class DbService : IDbService
    {
        private MainDbContext _context;
        public DbService(MainDbContext mainDbContext)
        {
            _context = mainDbContext;
        }

        public async Task<ClientOrder> AddOrder(AddOrderRequestDto order)
        {
            var newOrder = new ClientOrder
            {
                IdClientOrder = _context.ClientOrders.Max(s => s.IdClientOrder) + 1,
                OrderDate = DateTime.Now,
                Comments = order.Comments,
                IdClient = order.Client.IdClient,
                IdEmployee = _context.Employees.Select(s => s.ClientOrders).Min().Select(s => s.IdEmployee).FirstOrDefault(),
                Confectionery_ClientOrders = order.confectionery_ClientOrders
            };
            if (newOrder != null)
            {

                await _context.ClientOrders.AddAsync(newOrder);
                await _context.SaveChangesAsync();
                return newOrder;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetOrdersResponseDto>> GetOrder()
        {
            var orders = await _context.ClientOrders
                .Where(c => c.CompletionDate > DateTime.Now)
                .Select(c => new GetOrdersResponseDto
                {
                    DateOfSubmission = c.OrderDate,
                    Comment = c.Comments,
                    Name = c.Confectionery_ClientOrders.Select(s => s.Confectionery).Select(p => p.Name).FirstOrDefault(),
                    Quantity = c.Confectionery_ClientOrders.Select(s => s.Amount).FirstOrDefault(),
                    Employee = c.Employee

                })
                .OrderBy(c => c.DateOfSubmission)
                .ToListAsync();

            return orders;

        }
    }
}
