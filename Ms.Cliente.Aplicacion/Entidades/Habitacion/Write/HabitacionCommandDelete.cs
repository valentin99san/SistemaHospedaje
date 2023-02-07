using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Cliente.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Entidades.Cliente.Write
{
    public class ClienteCommandDelete
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Cliente> _habitacion;

        public ClienteCommandDelete()
        {
            _habitacion = _repository.db.GetCollection<dominio.Cliente>("Cliente");
        }

        public ActionResult<dominio.Cliente> Ok { get; private set; }

        public ActionResult<dominio.Cliente> EliminarProducto(string id)
        {
            _habitacion.DeleteOne(x => x._id == id);
            return Ok;
        }
    }
}
