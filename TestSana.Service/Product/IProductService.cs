using System.Collections.Generic;

namespace TestSana.Service.Product
{
    public interface IProductService : IBaseService
    {
        IEnumerable<Core.Models.Product> GetAllProducts();
        bool CreateProduct(Core.Models.Product createProductRequest);
    }
}