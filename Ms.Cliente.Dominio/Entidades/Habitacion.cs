using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Cliente.Dominio.Entidades
{
    [CollectionProperty("Cliente")]
    [BsonIgnoreExtraElements]
    public class Cliente : EntityToLower<ObjectId>
    {
        public int id_client { get; set; }

        public int num_client { get; set; }

        public int num_piso { get; set; }

        public string estado_client { get; set; }

        public string tipo_client { get; set; }
    }
}
