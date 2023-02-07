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
        private IMongoCollection<dominio.Cliente> _cliente;

        public ClienteCommandUpdate()
        {
            _cliente = _repository.db.GetCollection<dominio.Cliente>("Cliente");
        }

        public ActionResult<dominio.Cliente> ModificarCliente(dominio.Cliente cliente)
        {
            _cliente.ReplaceOne(x => x._id == cliente._id, cliente);
            return CreatedAtAction("ModificarCliente", cliente);
        }

        private ActionResult<dominio.Cliente> CreatedAtAction(string v, dominio.Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
