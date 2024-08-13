using CasaDoCodigo.Dominio;
using CasaDoCodigo.Aplicacao.Autor;
using CasaDoCodigo.Data;
using CasaDoCodigo.Aplicacao.Categoria;

namespace CasaDoCodigo.API.Configurations
{
    public static class DependencyResolve
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CriarNovoAutorHandler>();
            services.AddScoped<CriarCategoriaHandler>();
            return services;
        }

        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = configuration.GetConnectionString("Default");
            services.AddScoped<CasaDoCodigoContext>((db) => new CasaDoCodigoContext(connectionStrings));
            return services;
        }

    }
}
