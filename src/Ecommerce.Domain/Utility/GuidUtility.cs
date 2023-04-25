using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Utility
{
    public static class GuidUtility
    {
        public static bool IsNull(Guid guid)
        {
            return guid.Equals(Guid.Empty);
        }
    }
}
