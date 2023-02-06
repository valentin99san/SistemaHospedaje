using MongoDB.Driver;
using Ms.Pagos.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Pagos.Dominio.Entidades;

namespace Ms.Pagos.Aplicacion.Entidades.Read
{
    public class PagosQueryGetAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Pagos> _pagos;

        public PagosQueryGetAll()
        {
            _pagos = _repository.db.GetCollection<dominio.Pagos>("pagos");
        }

        public IEnumerable<dominio.Pagos> ListarHabitacion()
        {
            return _pagos.Find(x => true).ToList();
        }
    }
}
