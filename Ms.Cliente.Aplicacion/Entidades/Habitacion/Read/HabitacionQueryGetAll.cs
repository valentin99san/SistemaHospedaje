using Ms.Cliente.Infraestructura.DBRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Entidades.Cliente.Read
{
    public class ClienteQueryGetAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Cliente> _cliente;

        public ClienteQueryGetAll()
        {
            _cliente = _repository.db.GetCollection<dominio.Cliente>("cliente");
        }

        public IEnumerable<dominio.Cliente> ListarCliente()
        {
            return _cliente.Find(x => true).ToList();
        }
    }
}
