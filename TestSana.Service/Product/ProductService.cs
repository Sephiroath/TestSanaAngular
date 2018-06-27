using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestSana.Core.Models;
using TestSana.Core.ServiceEntities;

namespace TestSana.Service.Product
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(SanaCommerceTestContext context) : base(context)
        {
        }

        public IEnumerable<Core.Models.Product> GetAllProducts()
        {
            try
            {
                var result = Context.Product.ToList();
                return result;
            }
            catch (Exception e)
            {
                InsertErrorLog(e);
                throw;
            }
        }

        public bool CreateProduct(Core.Models.Product product)
        {
            try
            {
                Context.Product.Add(product);
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                InsertErrorLog(e);
                return false;
            }
        }
    }
}