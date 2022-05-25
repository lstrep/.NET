using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s20351Retake.Models.DTOs;
using s20351Retake.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s20351Retake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IDbService _dbService;
        public OrdersController(IDbService database)
        {
            _dbService = database;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var info = await _dbService.GetOrder();
            if (info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequestDto order)
        {
            var newOrder = await _dbService.AddOrder(order);
            if (newOrder == null)
            {
                return StatusCode(400);
            }

            return Ok(newOrder);
        }


    }
}
