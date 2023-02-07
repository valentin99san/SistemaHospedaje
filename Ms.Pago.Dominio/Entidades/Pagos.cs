using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Pago.Dominio.Entidades
{
    [CollectionProperty("pagos")]
    [BsonIgnoreExtraElements]
    public class Pagos : EntityToLower<ObjectId>
    {
        //public int idPago;

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        public int idComprobante { get; set; }

        public string detalleAlquiler { get; set; }

        public double precioUnd { get; set; }

        public double precioTotal { get; set; }

        public double montoTotal { get; set; }
    }
}
