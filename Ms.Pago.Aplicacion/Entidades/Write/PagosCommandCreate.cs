using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pago.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Pago.Dominio.Entidades;

namespace Ms.Pago.Aplicacion.Entidades.Write
{
    public class PagosCommandCreate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Pagos> _pagos;


        public PagosCommandCreate()
        {
            _pagos = _repository.db.GetCollection<dominio.Pagos>("Pagos");
        }

        public ActionResult<dominio.Pagos> CrearPagos(dominio.Pagos pagos)
        {
            pagos.Id = ObjectId.GenerateNewId().ToString();
            _pagos.InsertOne(pagos);

            return CreatedAtAction("CrearPagos", pagos);
        }

        private ActionResult<dominio.Pagos> CreatedAtAction(string v, dominio.Pagos pagos)
        {
            throw new NotImplementedException();
        }
    }
}
