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
        private readonly ICollectionContext<dominio.Cliente> _habitacion;
        private readonly IBaseRepository<dominio.Cliente> _habitacionR;

        public ClienteService(ICollectionContext<dominio.Cliente> habitacion,
                                IBaseRepository<dominio.Cliente> habitacionR)
        {
            _habitacion = habitacion;
            _habitacionR = habitacionR;
        }

        public List<dominio.Cliente> ListarClientees()
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false;
            var items = (_habitacion.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registrar(dominio.Cliente producto)
        {
            producto.esEliminado = false;
            producto.fechaCreacion = DateTime.Now;
            producto.esActivo = true;

            // _producto.Context().InsertOne(producto);                       

            var p = _habitacionR.InsertOne(producto);

            return true;
        }

        public dominio.Cliente BuscarPorId(int idhabitacion)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.id_habit == idhabitacion;
            var item = (_habitacion.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCliente)
        {
            Expression<Func<dominio.Cliente, bool>> filter = s => s.esEliminado == false && s.id_habit == idCliente;
            var item = (_habitacion.Context().FindOneAndDelete(filter, null));

        }

        public bool Modificar(dominio.Cliente producto)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarStock(int idCliente)
        {
            var habitacion = BuscarPorId(idCliente);

            _habitacionR.UpdateOne(habitacion.id, habitacion);

            return true;
        }

     
    }
}
