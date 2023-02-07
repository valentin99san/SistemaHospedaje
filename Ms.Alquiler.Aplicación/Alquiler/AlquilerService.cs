using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using dominio = Ms.Alquiler.Dominio.Entidades;
using Release.MongoDB.Repository;
using Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Alquiler
{
    public class AlquilerService : IAlquilerService
    {
        private readonly ICollectionContext<dominio.Alquiler> _alquiler;
        private readonly IBaseRepository<dominio.Alquiler> _alquilerR;

        public AlquilerService(ICollectionContext<dominio.Alquiler> alquiler,
                                IBaseRepository<dominio.Alquiler> alquilerR)
        {
            _alquiler = alquiler;
            _alquilerR = alquilerR;
        }

        public List<dominio.Alquiler> ListarAlquiler()
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false;
            var items = (_alquiler.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registrar(dominio.Alquiler alquiler)
        {
            alquiler.esEliminado = false;
            alquiler.fechaCreacion = DateTime.Now;
            alquiler.esActivo = true;

                                  

            var p = _alquilerR.InsertOne(alquiler);

            return true;
        }

        public dominio.Alquiler BuscarPorId(int idAlquiler)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.id_alqui == idAlquiler;
            var item = (_alquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idAlquiler)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.id_alqui == idAlquiler;
            var item = (_alquiler.Context().FindOneAndDelete(filter, null));

        }

        public bool Modificar(dominio.Alquiler producto)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarStock(int idAlquiler)
        {
            var alquiler = BuscarPorId(idAlquiler);

            _alquilerR.UpdateOne(alquiler.id, alquiler);

            return true;
        }

     
    }
}
