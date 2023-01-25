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
    public class HabitacionCommandDelete
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Habitacion> _habitacion;

        public HabitacionCommandDelete()
        {
            _habitacion = _repository.db.GetCollection<dominio.Habitacion>("Habitacion");
        }

        public ActionResult<dominio.Habitacion> Ok { get; private set; }

        public ActionResult<dominio.Habitacion> EliminarProducto(string id)
        {
            _habitacion.DeleteOne(x => x._id == id);
            return Ok;
        }
    }
}
