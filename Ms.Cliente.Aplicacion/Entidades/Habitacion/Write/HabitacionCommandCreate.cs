using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Ms.Cliente.Infraestructura.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Cliente.Dominio.Entidades;
using System.Linq.Expressions;

namespace Ms.Cliente.Aplicacion.Entidades.Cliente.Write
{
    public class ClienteCommandCreate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Cliente> _cliente;
        

        public ClienteCommandCreate()
        {      
            _cliente = _repository.db.GetCollection<dominio.Cliente>("Cliente");
        }

        public ActionResult<dominio.Cliente> CrearCliente(dominio.Cliente cliente)
        {
            cliente._id = ObjectId.GenerateNewId().ToString();
            _cliente.InsertOne(cliente);        
           
           return CreatedAtAction("CrearCliente", cliente);
        }

        private ActionResult<dominio.Cliente> CreatedAtAction(string v, dominio.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        
    }
}
