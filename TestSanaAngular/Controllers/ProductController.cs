using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSana.Core.Models;
using TestSana.Core.ServiceEntities;
using TestSana.Service;
using TestSana.Service.Product;
using TestSanaAngular.ViewModels;

namespace TestSanaAngular.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ProductListViewModel Get(ProductListRequest productListRequest)
        {
            var result = new ProductListViewModel { IsError = true };
            try
            {
                if (productListRequest.IsPersistentStorage)
                    result.Product = _productService.GetAllProducts();
                else
                {
                    var options = GetDbContextOptionsBuilder();
                    using (var context = new SanaCommerceTestContext(options))
                    {
                        _productService.ChangeCurrentContext(context);
                        result.Product = _productService.GetAllProducts();
                    }
                }
            }
            catch
            {
                return result;
            }
            result.IsError = false;
            return result;
        }

        [HttpPost]
        public bool Post([FromBody]CreateProductRequest createProductRequest)
        {
            bool result;
            if (createProductRequest.IsPersistentStorage)
                result = _productService.CreateProduct(createProductRequest.Product);
            else
            {
                var options = GetDbContextOptionsBuilder();
                using (var context = new SanaCommerceTestContext(options))
                {
                    _productService.ChangeCurrentContext(context);
                    createProductRequest.Product.ProductId += _productService.GetAllProducts().Count();
                    result = _productService.CreateProduct(createProductRequest.Product);
                }
            }
            return result;
        }

        private DbContextOptions<SanaCommerceTestContext> GetDbContextOptionsBuilder()
        {
            return new DbContextOptionsBuilder<SanaCommerceTestContext>()
                .UseInMemoryDatabase(databaseName: "PRODUCTDATABASE")
                .Options;
        }
    }
}