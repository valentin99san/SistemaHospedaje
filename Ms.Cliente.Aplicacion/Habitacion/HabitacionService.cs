using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using dominio = Ms.Cliente.Dominio.Entidades;
using Release.MongoDB.Repository;

namespace Ms.Cliente.Aplicacion.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly ICollectionContext<dominio.Cliente> _cliente;
        private readonly IBaseRepository<dominio.Cliente> _clienteR;

        public ClienteService(ICollectionContext<dominio.Cliente> cliente,
                                IBaseRepository<dominio.Cliente> clienteR)
        {
            _cliente = cliente;
            _clienteR = clienteR;
        }

        public List<dominio.Cliente> ListarClientees()
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false;
            var items = (_cliente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registrar(dominio.Cliente producto)
        {
            producto.esEliminado = false;
            producto.fechaCreacion = DateTime.Now;
            producto.esActivo = true;

            // _producto.Context().InsertOne(producto);                       

            var p = _clienteR.InsertOne(producto);

            return true;
        }

        public dominio.Cliente BuscarPorId(int idcliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.id_habit == idcliente;
            var item = (_cliente.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.id_habit == idCliente;
            var item = (_cliente.Context().FindOneAndDelete(filter, null));

        }

        public bool Modificar(dominio.Cliente producto)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarStock(int idCliente)
        {
            var cliente = BuscarPorId(idCliente);

            _clienteR.UpdateOne(cliente.id, cliente);

            return true;
        }

     
    }
}
