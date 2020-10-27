using Equinox.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Application.Interfaces;
using WebApi.Application.Services;
using WebApi.Domain.Core.Bus;
using WebApi.Domain.Interfaces;
using WebApi.Infra.Bus;
using WebApi.Infra.Data.Repository;
using WebApi.Infra.Data.UoW;
using WebApi.Infra.Identity;
using WebApi.Infra.Identity.Models;

namespace WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
            // Application
            services.AddScoped<IClienteAppService, ClienteAppService> ();
            services.AddScoped<IOperadoraAppService, OperadoraAppService>();
            services.AddScoped<IPlanoAppService, PlanoAppService>();

            // Infra - Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOperadoraRepository, OperadoraRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
