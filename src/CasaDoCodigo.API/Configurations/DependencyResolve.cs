using CasaDoCodigo.Dominio;
using CasaDoCodigo.Aplicacao.Autor;
using CasaDoCodigo.Data;

namespace CasaDoCodigo.API.Configurations
{
    public static class DependencyResolve
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CriarNovoAutorHandler>();
            return services;
        }

        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            return services;
        }
    }
}
