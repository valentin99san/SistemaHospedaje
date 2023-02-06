using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Habitacion.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Habitacion.Dominio.Entidades;
using System.Linq.Expressions;

namespace Ms.Habitacion.Aplicacion.Entidades.Habitacion.Write
{
    public class HabitacionCommandCreate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Habitacion> _habitacion;
        

        public HabitacionCommandCreate()
        {      
            _habitacion = _repository.db.GetCollection<dominio.Habitacion>("Habitacion");
        }

        public ActionResult<dominio.Habitacion> CrearHabitacion(dominio.Habitacion habitacion)
        {
            habitacion._id = ObjectId.GenerateNewId().ToString();
            _habitacion.InsertOne(habitacion);        
           
           return CreatedAtAction("CrearHabitacion", habitacion);
        }

        private ActionResult<dominio.Habitacion> CreatedAtAction(string v, dominio.Habitacion habitacion)
        {
            throw new NotImplementedException();
        }

        
    }
}
