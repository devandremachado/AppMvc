using App.BLL.Interfaces;
using App.BLL.Interfaces.Repositories;
using App.BLL.Interfaces.Services;
using App.BLL.Notificacoes;
using App.BLL.Services;
using App.Data.Context;
using App.Data.Repository;
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
