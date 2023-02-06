using Ms.Habitacion.Infraestructura.DBRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Habitacion.Dominio.Entidades;

namespace Ms.Habitacion.Aplicacion.Entidades.Habitacion.Read
{
    public class HabitacionQueryGetAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Habitacion> _habitacion;

        public HabitacionQueryGetAll()
        {
            _habitacion = _repository.db.GetCollection<dominio.Habitacion>("habitacion");
        }

        public IEnumerable<dominio.Habitacion> ListarHabitacion()
        {
            return _habitacion.Find(x => true).ToList();
        }
    }
}
