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
    public class ClienteCommandUpdate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Cliente> _habitacion;

        public ClienteCommandUpdate()
        {
            _habitacion = _repository.db.GetCollection<dominio.Cliente>("Cliente");
        }

        public ActionResult<dominio.Cliente> ModificarCliente(dominio.Cliente habitacion)
        {
            _habitacion.ReplaceOne(x => x._id == habitacion._id, habitacion);
            return CreatedAtAction("ModificarCliente", habitacion);
        }

        private ActionResult<dominio.Cliente> CreatedAtAction(string v, dominio.Cliente habitacion)
        {
            throw new NotImplementedException();
        }
    }
}
