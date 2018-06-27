using TestSana.Core.Models;

namespace TestSana.Service
{
    public interface IBaseService
    {
        void ChangeCurrentContext(SanaCommerceTestContext sanaCommerceTestContext);
    }
}