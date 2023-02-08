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
        public object _id;

        //public int idPago;

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        public int idComprobante { get; set; }

        public int Cantidad { get; set; }

        public string detalleAlquiler { get; set; }

        public decimal precioUnd { get; set; }

        public decimal precioTotal { get; set; }
        public string Id { get; set; }
    }
}
