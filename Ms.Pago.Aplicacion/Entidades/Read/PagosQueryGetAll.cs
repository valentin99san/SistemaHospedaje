using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Pago.Dominio.Entidades;
using Ms.Pago.Infraestructura;

namespace Ms.Pago.Aplicacion.Entidades.Read
{
    public class PagosQueryGetAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Pagos> _pagos;

        public PagosQueryGetAll()
        {
            _pagos = _repository.db.GetCollection<dominio.Pagos>("pagos");
        }

        public IEnumerable<dominio.Pagos> ListarPagos()
        {
            return _pagos.Find(x => true).ToList();
        }
    }
}
