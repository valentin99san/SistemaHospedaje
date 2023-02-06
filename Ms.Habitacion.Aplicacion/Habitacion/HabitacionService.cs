using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using dominio = Ms.Habitacion.Dominio.Entidades;
using Release.MongoDB.Repository;

namespace Ms.Habitacion.Aplicacion.Habitacion
{
    public class HabitacionService : IHabitacionService
    {
        private readonly ICollectionContext<dominio.Habitacion> _habitacion;
        private readonly IBaseRepository<dominio.Habitacion> _habitacionR;

        public HabitacionService(ICollectionContext<dominio.Habitacion> habitacion,
                                IBaseRepository<dominio.Habitacion> habitacionR)
        {
            _habitacion = habitacion;
            _habitacionR = habitacionR;
        }

        public List<dominio.Habitacion> ListarHabitaciones()
        {
            Expression<Func<dominio.Habitacion, bool>> filter = s => s.esEliminado == false;
            var items = (_habitacion.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registrar(dominio.Habitacion producto)
        {
            producto.esEliminado = false;
            producto.fechaCreacion = DateTime.Now;
            producto.esActivo = true;

            // _producto.Context().InsertOne(producto);                       

            var p = _habitacionR.InsertOne(producto);

            return true;
        }

        public dominio.Habitacion BuscarPorId(int idhabitacion)
        {
            Expression<Func<dominio.Habitacion, bool>> filter = s => s.esEliminado == false && s.id_habit == idhabitacion;
            var item = (_habitacion.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idHabitacion)
        {
            Expression<Func<dominio.Habitacion, bool>> filter = s => s.esEliminado == false && s.id_habit == idHabitacion;
            var item = (_habitacion.Context().FindOneAndDelete(filter, null));

        }

        public bool Modificar(dominio.Habitacion producto)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarStock(int idHabitacion)
        {
            var habitacion = BuscarPorId(idHabitacion);

            _habitacionR.UpdateOne(habitacion.id, habitacion);

            return true;
        }

     
    }
}
