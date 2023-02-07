using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.Pago.Infraestructura
{
    public class DBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public DBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("DB_Pago");
        }
    }
}
