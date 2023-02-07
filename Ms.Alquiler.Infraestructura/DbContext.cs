using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.Alquiler.Infraestructura
{
    public class DbContext : DataContext, IDbContext
    {
        public DbContext(MongoUrl mongoUrl) : base(mongoUrl)
        {

        }
    }
}
