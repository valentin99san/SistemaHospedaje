using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Alquiler.Dominio.Entidades
{
    [CollectionProperty("Alquiler")]
    [BsonIgnoreExtraElements]
    public class Alquiler : EntityToLower<ObjectId>
    {
        public int id_alqui{ get; set; }

        public int num_alqui { get; set; }

        public int num_piso { get; set; }

        public string estado_alqui { get; set; }

        public string tipo_alqui { get; set; }
    }
}
