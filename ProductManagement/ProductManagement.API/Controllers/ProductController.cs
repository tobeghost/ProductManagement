using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<GetProductsResponse> GetAllProducts()
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

            return re;
        }

        [HttpGet("{categoryId}")]
        public async Task<GetProductsResponse> GetProductsByCategoryId(int categoryId)
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

            return re;
        }
    }
}
