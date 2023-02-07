using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Alquiler.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Alquiler.Dominio.Entidades;
using System.Linq.Expressions;
using Ms.Alquiler.Infraestructura.DBRepository;

namespace Ms.Alquiler.Aplicacion.Entidades.Alquiler.Write
{
    public class AlquilerCommandCreate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Alquiler> _alquiler;
        

        public AlquilerCommandCreate()
        {
            _alquiler = _repository.db.GetCollection<dominio.Alquiler>("Alquiler");
        }

        public ActionResult<dominio.Alquiler> CrearHabitacion(dominio.Alquiler alquiler)
        {
            alquiler._id = ObjectId.GenerateNewId().ToString();
            _alquiler.InsertOne(alquiler);        
           
           return CreatedAtAction("CrearAlquiler", alquiler);
        }

        private ActionResult<dominio.Alquiler> CreatedAtAction(string v, dominio.Alquiler alquiler)
        {
            throw new NotImplementedException();
        }

        
    }
}
