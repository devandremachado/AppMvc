using App.Domain.Interfaces;
using App.Domain.Interfaces.Repositories;
using App.Domain.Interfaces.Services;
using App.Domain.Notificacoes;
using App.Domain.Services;
using App.Infra.Context;
using App.Infra.Repository;
using App.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.WebUI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }

        private static object IFornecedorServidor(IServiceProvider arg)
        {
            throw new NotImplementedException();
        }
    }
}
