using TestSana.Core.Models;

namespace TestSana.Core.ServiceEntities
{
    public class CreateProductRequest
    {
        public Product Product { get; set; }
        public bool IsPersistentStorage { get; set; }
    }
}