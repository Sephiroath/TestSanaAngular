using System.Collections.Generic;
using TestSana.Core.Models;

namespace TestSanaAngular.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public bool IsError { get; set; }
    }
}