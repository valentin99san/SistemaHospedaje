using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.Pagos.Dominio.Entidades
{
    public class Pagos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int id_habit { get; set; }

        public int num_habit { get; set; }

        public int num_piso { get; set; }

        public string estado_habit { get; set; }

        public string tipo_habit { get; set; }
    }
}
