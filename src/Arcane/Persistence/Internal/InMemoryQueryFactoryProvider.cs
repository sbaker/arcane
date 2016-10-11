using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.Persistence.Internal
{
    internal class InMemoryQueryFactoryProvider : QueryFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new InMemoryQueryFactory(context);
        }
    }
}
