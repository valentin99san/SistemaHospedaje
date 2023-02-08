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
    public class PagosCommandUpdate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Pagos> _pagos;

        public PagosCommandUpdate()
        {
            _pagos = _repository.db.GetCollection<dominio.Pagos>("pagos");
        }

        public ActionResult<dominio.Pagos> ModificarPagos(dominio.Pagos pagos)
        {
            _pagos.ReplaceOne(x => x.Id == pagos._id, pagos);
            return CreatedAtAction("ModificarPagos", pagos);
        }

        private ActionResult<dominio.Pagos> CreatedAtAction(string v, dominio.Pagos pagos
            )
        {
            throw new NotImplementedException();
        }
    }
}
