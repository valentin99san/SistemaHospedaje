using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Ms.Pago.Aplicacion.Services;
using Ms.Pago.Infraestructura;
using dominio = Ms.Pago.Dominio.Entidades;

namespace Ms.Pago.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Pagos>>(x => new CollectionContext<dominio.Pagos>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Pagos>>(x => new BaseRepository<dominio.Pagos>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IPagoService, PagoService>();

            #endregion

            return services;
        }
    }
}
