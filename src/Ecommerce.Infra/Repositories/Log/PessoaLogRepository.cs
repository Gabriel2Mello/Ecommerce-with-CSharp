using Ecommerce.Domain.Log;
using Ecommerce.Infra.Base;
using Ecommerce.Infra.Context;

namespace Ecommerce.Infra.Repositories.Log
{
    public class PessoaLogRepository : RepositoryBase<PessoaLog>
    {
        public PessoaLogRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}
