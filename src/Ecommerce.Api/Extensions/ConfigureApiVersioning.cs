using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Ecommerce.Api.Extensions
{
    public static class ConfigureApiVersioning
    {
        public static void AddApiVersioningConfigured(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("Accept-Version"),
                    new MediaTypeApiVersionReader("api-version"),
                    new UrlSegmentApiVersionReader()
                    );

                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
