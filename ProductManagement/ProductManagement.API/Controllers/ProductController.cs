using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.Domain.Catalog;
using PM.Services.Catalog;
using ProductManagement.API.Models;
using ProductManagement.API.Models.Product;
using ProductManagement.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
    [Route("product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var re = new CreateProductResponse();

            try
            {
                var new_product = _mapper.Map<Product>(createProductDto);

                if (createProductDto.Categories != null)
                {
                    foreach (var item in createProductDto.Categories)
                    {
                        new_product.ProductCategories.Add(new ProductCategory()
                        {
                            CategoryId = item
                        });
                    }
                }

                await _productService.InsertProduct(new_product);

                return RedirectToAction("GetProductById", "Product", new { productId = new_product.Id });
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }

        [HttpGet("{productId}/detail")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var re = new GetProductResponse();

            try
            {
                var product = await _productService.GetProductById(productId);

                var data = _mapper.Map<ProductDto>(product);

                re.Success(data);
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var re = new GetProductsResponse();

            try
            {
                var products = await _productService.GetAllProducts();

                var data = _mapper.Map<List<ProductDto>>(products);

                re.Success(data);
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }

        [HttpGet("{categoryId}/all")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var re = new GetProductsResponse();

            try
            {
                var products = await _productService.GetProductsByCategoryId(categoryId);

                var data = _mapper.Map<List<ProductDto>>(products);

                re.Success(data);
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }

        [HttpPost("{productId}/active")]
        public async Task<IActionResult> SetActive(int productId)
        {
            var re = new BaseResponse();

            try
            {
                await _productService.ChangeStatusOfProductById(productId, true);

                re.Success();
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }

        [HttpPost("{productId}/passive")]
        public async Task<IActionResult> SetPassive(int productId)
        {
            var re = new BaseResponse();

            try
            {
                await _productService.ChangeStatusOfProductById(productId, false);

                re.Success();
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }
    }
}
