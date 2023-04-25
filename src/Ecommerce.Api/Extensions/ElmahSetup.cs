using ElmahCore.Mvc;
using ElmahCore.Sql;

namespace Ecommerce.Api.Extensions
{
    internal static class ElmahSetup
    {
        public static void AddElmahCore(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("Ecommerce");
                options.Path = "/elmah";
            });
        }
    }
}
