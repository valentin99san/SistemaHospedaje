using Microsoft.AspNetCore.Mvc;
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
    public class PagosCommandDelete
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Pagos> _pagos;

        public PagosCommandDelete()
        {
            _pagos = _repository.db.GetCollection<dominio.Pagos>("pagos");
        }

        public ActionResult<dominio.Pagos> Ok { get; private set; }

        public ActionResult<dominio.Pagos> EliminarPagos(string id)
        {
            _pagos.DeleteOne(x => x.Id == id);
            return Ok;
        }
    }
}
