using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Ms.Alquiler.Infraestructura;
using Release.MongoDB.Repository;
using dominio = Ms.Alquiler.Dominio.Entidades;
using Ms.Alquiler.Aplicacion.Alquiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ms.Alquiler.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Alquiler>>(x => new CollectionContext<dominio.Alquiler>(x.GetService<IDbContext>()));
            

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Alquiler>>(x => new BaseRepository<dominio.Alquiler>(x.GetService<IDbContext>()));
           

            #endregion

            #region Servicios

            services.AddScoped<IAlquilerService, AlquilerService>();
            

            #endregion

            return services;
        }
    }
}
