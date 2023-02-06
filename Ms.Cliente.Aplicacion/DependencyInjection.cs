using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Ms.Habitacion.Infraestructura;
using Release.MongoDB.Repository;
using dominio = Ms.Habitacion.Dominio.Entidades;
using Ms.Habitacion.Aplicacion.Habitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ms.Habitacion.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Habitacion>>(x => new CollectionContext<dominio.Habitacion>(x.GetService<IDbContext>()));
            

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Habitacion>>(x => new BaseRepository<dominio.Habitacion>(x.GetService<IDbContext>()));
           

            #endregion

            #region Servicios

            services.AddScoped<IHabitacionService, HabitacionService>();
            

            #endregion

            return services;
        }
    }
}
