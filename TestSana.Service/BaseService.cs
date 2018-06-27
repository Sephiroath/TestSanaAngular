using System;
using TestSana.Core.Models;

namespace TestSana.Service
{
    public abstract class BaseService : IBaseService
    {
        protected SanaCommerceTestContext Context;

        protected BaseService(SanaCommerceTestContext context)
        {
            Context = context;
        }

        public void ChangeCurrentContext(SanaCommerceTestContext sanaCommerceTestContext)
        {
            Context = sanaCommerceTestContext;
        }

        protected void InsertErrorLog(Exception ex)
        {
            //TODO: Log Error
        }
    }
}