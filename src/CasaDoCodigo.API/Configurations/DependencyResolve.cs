using CasaDoCodigo.Data;
using CasaDoCodigo.Dominio;
using CasaDoCodigo.Aplicacao.Pais;
using CasaDoCodigo.Aplicacao.Livro;
using CasaDoCodigo.Aplicacao.Autor;
using CasaDoCodigo.Aplicacao.Estado;
using CasaDoCodigo.Aplicacao.Compra;
using CasaDoCodigo.Aplicacao.Categoria;
using CasaDoCodigo.Aplicacao.Cupom;

namespace CasaDoCodigo.API.Configurations
{
    public static class DependencyResolve
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CriarNovoAutorHandler>();
            services.AddScoped<CriarCategoriaHandler>();
            services.AddScoped<CriarLivroHandler>();
            services.AddScoped<CriarPaisHandler>();
            services.AddScoped<CriarEstadoHandler>();
            services.AddScoped<CriarCompraHandler>();
            services.AddScoped<CriarCupomHandler>();
            services.AddScoped<ObterTodosOsLivrosHandler>();
            services.AddScoped<ObterLivroPorIdHandler>();
            services.AddScoped<ObterCompraHandler>();
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
