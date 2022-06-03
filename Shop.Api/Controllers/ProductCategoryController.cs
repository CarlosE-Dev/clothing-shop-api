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
    [Route("productcategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _prodCategoryService;

        public ProductCategoryController(IMapper mapper, IProductCategoryService service)
        {
            _mapper = mapper;
            _prodCategoryService = service;
        }

        [Authorize(Roles = "customer, admin")]
        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            var prodCategory = _mapper.Map<IEnumerable<ProductCategoryDTO>>(await _prodCategoryService.GetAllAsync());

            return Ok(prodCategory);
        }

        [Authorize(Roles = "customer, admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(long id)
        {
            var prodCategory = _mapper.Map<ProductCategoryDTO>(await _prodCategoryService.GetById(id));

            if (prodCategory == null)
            {
                return NotFound();
            }

            return Ok(prodCategory);
        }

        [Authorize(Roles = "admin")]
        [Route("update/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(long id, ProductCategoryDTO prodCategoryDto)
        {
            if (id != prodCategoryDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var prodCategory = _mapper.Map<ProductCategory>(prodCategoryDto);
                await _prodCategoryService.Update(prodCategory);
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
        public async Task<ActionResult<ProductCategory>> CreateProduct(ProductCategoryDTO prodCategoryDto)
        {
            var prodCategory = _mapper.Map<ProductCategory>(prodCategoryDto);
            await _prodCategoryService.Create(prodCategory);

            return CreatedAtAction("GetProductCategory", new { id = prodCategory.Id }, prodCategory);
        }

        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(long id)
        {

            try
            {
                await _prodCategoryService.Delete(id);
            }
            catch
            {
                throw new Exception("An error ocurred!");
            }

            return NoContent();
        }
    }
}
