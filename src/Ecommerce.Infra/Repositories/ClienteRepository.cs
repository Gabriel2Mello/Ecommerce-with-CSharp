using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infra.Base;
using Ecommerce.Infra.Context;

namespace Ecommerce.Infra.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}
