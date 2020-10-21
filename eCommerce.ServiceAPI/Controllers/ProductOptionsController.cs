using eCommerce.Application.Dto;
using eCommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eCommerce.ServiceAPI.Controllers
{
    [Route("api/Products/{productId}/[controller]")]
    [ApiController]
    public class ProductOptionsController : Controller
    {
        private readonly IProductOptionService _productOptionService;

        public ProductOptionsController(IProductOptionService productOptionService)
        {
            this._productOptionService = productOptionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductOptions(Guid productId)
        {
            try
            {
                var products = await _productOptionService.GetAllAsync(productId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productOptionId}")]
        public async Task<ActionResult> GetProductOptions(Guid productId, Guid productOptionId)
        {
            try
            {
                var productOptionDto = await _productOptionService.GetProductOptionAsync(productId, productOptionId);
                return Ok(productOptionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductOptionDto productOptionDto)
        {
            try
            {
                await _productOptionService.AddAsync(productOptionDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productOptionId}")]
        public async Task<ActionResult> Update(Guid productId, Guid productOptionId, ProductOptionDto productOptionDto)
        {
            try
            {
                await _productOptionService.UpdateAsync(productId, productOptionId, productOptionDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productOptionId}")]
        public async Task<ActionResult> Delete(Guid productId, Guid productOptionId)
        {
            try
            {
                await _productOptionService.DeleteAsync(productId, productOptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}