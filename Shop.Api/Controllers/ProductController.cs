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
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _prodService;

        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _prodService = service;
        }

        [Authorize(Roles = "customer, admin")]
        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = _mapper.Map<IEnumerable<ProductDTO>>(await _prodService.GetAllAsync());
            
            return Ok(products);
        }

        [Authorize(Roles = "customer, admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = _mapper.Map<ProductDTO>(await _prodService.GetById(id));

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Authorize(Roles = "admin")]
        [Route("update/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, ProductDTO productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _prodService.Update(product);
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
        public async Task<ActionResult<Product>> CreateProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _prodService.Create(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {

            try
            {
                await _prodService.Delete(id);
            }
            catch
            {
                throw new Exception("An error ocurred!");
            }

            return NoContent();
        }
    }
}
