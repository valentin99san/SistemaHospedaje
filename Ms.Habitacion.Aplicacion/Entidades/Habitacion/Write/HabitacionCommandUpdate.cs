using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Habitacion.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Habitacion.Dominio.Entidades;

namespace Ms.Habitacion.Aplicacion.Entidades.Habitacion.Write
{
    public class HabitacionCommandUpdate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Habitacion> _habitacion;

        public HabitacionCommandUpdate()
        {
            _habitacion = _repository.db.GetCollection<dominio.Habitacion>("Habitacion");
        }

        public ActionResult<dominio.Habitacion> ModificarHabitacion(dominio.Habitacion habitacion)
        {
            _habitacion.ReplaceOne(x => x._id == habitacion._id, habitacion);
            return CreatedAtAction("ModificarHabitacion", habitacion);
        }

        private ActionResult<dominio.Habitacion> CreatedAtAction(string v, dominio.Habitacion habitacion)
        {
            throw new NotImplementedException();
        }
    }
}
