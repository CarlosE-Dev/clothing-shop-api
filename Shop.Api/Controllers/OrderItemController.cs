using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("orderitem")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemService _oItemService;

        public OrderItemController(IMapper mapper, IOrderItemService service)
        {
            _mapper = mapper;
            _oItemService = service;
        }

        [Authorize(Roles = "customer, admin")]
        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            var orderItems = _mapper.Map<IEnumerable<OrderItemDTO>>(await _oItemService.GetAllAsync());

            if (orderItems == null)
            {
                return NotFound();
            }

            return Ok(orderItems);
        }

        [Authorize(Roles = "customer, admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(long id)
        {
            var oItem = _mapper.Map<OrderItemDTO>(await _oItemService.GetById(id));

            if (oItem == null)
            {
                return NotFound();
            }

            return Ok(oItem);
        }

        [Authorize(Roles = "admin")]
        [Route("update/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(long id, OrderItemDTO oItemDto)
        {
            if (id != oItemDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var oItem = _mapper.Map<OrderItem>(oItemDto);
                await _oItemService.Update(oItem);
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
        public async Task<ActionResult<OrderItem>> CreateOrderItem(OrderItemDTO oItemDto)
        {
            var oItem = _mapper.Map<OrderItem>(oItemDto);
            await _oItemService.Create(oItem);

            return CreatedAtAction("GetOrderItem", new { id = oItem.Id }, oItem);
        }

        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(long id)
        {

            try
            {
                await _oItemService.Delete(id);
            }
            catch
            {
                throw new Exception("An error ocurred!");
            }

            return NoContent();
        }
    }
}
