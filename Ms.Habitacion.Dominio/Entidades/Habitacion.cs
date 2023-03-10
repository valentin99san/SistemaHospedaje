using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Habitacion.Dominio.Entidades
{
    [CollectionProperty("Habitacion")]
    [BsonIgnoreExtraElements]
    public class Habitacion : EntityToLower<ObjectId>
    {
        public int id_habit { get; set; }

        public int num_habit { get; set; }

        public int num_piso { get; set; }

        public string estado_habit { get; set; }

        public string tipo_habit { get; set; }
    }
}
