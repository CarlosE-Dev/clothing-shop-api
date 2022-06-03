using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService service)
        {
            _mapper = mapper;
            _orderService = service;
        }

        [Authorize(Roles = "customer, admin")]
        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var ordersDto = await _orderService.GetAllDTOAsync();
            return Ok(ordersDto);
        }

        [Authorize(Roles = "customer, admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var orderDto = await _orderService.GetDTOById(id);
            return Ok(orderDto);
        }

        [Authorize(Roles = "admin")]
        [Route("update/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(long id, OrderDTO orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var order = _mapper.Map<Order>(orderDto);
                await _orderService.Update(order);
            }

            catch
            {
                throw new Exception("An error ocurred!");
            }

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderService.Create(order);

            return CreatedAtAction("GetOrderItem", new { id = order.Id }, order);
        }

        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {

            try
            {
                await _orderService.Delete(id);
            }
            catch
            {
                throw new Exception("An error ocurred!");
            }

            return NoContent();
        }
    }
}