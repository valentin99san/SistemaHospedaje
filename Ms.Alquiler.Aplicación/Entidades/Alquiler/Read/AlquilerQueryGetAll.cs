using Ms.Habitacion.Infraestructura.DBRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Entidades.Habitacion.Read
{
    public class AlquilerQueryGetAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Alquiler> _alquiler;

        public AlquilerQueryGetAll()
        {
            _alquiler = _repository.db.GetCollection<dominio.Alquiler>("alquiler");
        }

        public IEnumerable<dominio.Alquiler> ListarAlquiler()
        {
            return _alquiler.Find(x => true).ToList();
        }
    }
}
