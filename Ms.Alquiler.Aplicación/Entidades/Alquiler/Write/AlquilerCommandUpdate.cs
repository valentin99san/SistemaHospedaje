using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Habitacion.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Entidades.Alquiler.Write
{
    public class AlquilerCommandUpdate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Alquiler> _alquiler;

        public AlquilerCommandUpdate()
        {
            _alquiler = _repository.db.GetCollection<dominio.Alquiler>("Alquiler");
        }

        public ActionResult<dominio.Alquiler> ModificarAlquiler(dominio.Alquiler alquiler)
        {
            _alquiler.ReplaceOne(x => x._id == alquiler._id, alquiler);
            return CreatedAtAction("ModificarAlquiler", alquiler);
        }

        private ActionResult<dominio.Alquiler> CreatedAtAction(string v, dominio.Alquiler alquiler)
        {
            throw new NotImplementedException();
        }
    }
}
