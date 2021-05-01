using App.BLL.Interfaces;
using App.Data.Context;
using App.Data.Repository;
using App.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
