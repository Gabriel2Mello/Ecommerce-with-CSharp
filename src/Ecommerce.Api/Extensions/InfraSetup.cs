﻿using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Application.Services.Log;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infra.Base;
using Ecommerce.Infra.Context;
using Ecommerce.Infra.Repositories;
using Ecommerce.Infra.Repositories.Log;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Extensions
{
    internal static class InfraSetup
    {
        public static void UseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Ecommerce");
            services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(connectionString));
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<PessoaLogRepository, PessoaLogRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<PessoaLogService, PessoaLogService>();

            return services;
        }
    }
}
