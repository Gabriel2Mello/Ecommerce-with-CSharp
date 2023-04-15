using Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Extensions
{
    internal static class EcommerceContextSetup
    {
        public static void UseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Ecommerce");
            services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
