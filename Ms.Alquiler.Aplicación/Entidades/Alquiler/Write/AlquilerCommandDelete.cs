using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Alquiler.Dominio.Entidades;
using Ms.Alquiler.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Entidades.Alquiler.Write
{
    public class AlquilerCommandDelete
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Alquiler> _alquiler;

        public AlquilerCommandDelete()
        {
            _alquiler = _repository.db.GetCollection<dominio.Alquiler>("Alquiler");
        }

        public ActionResult<dominio.Alquiler> Ok { get; private set; }

        public ActionResult<dominio.Alquiler> EliminarProducto(string id)
        {
            _alquiler.DeleteOne(x => x._id == id);
            return Ok;
        }
    }
}
