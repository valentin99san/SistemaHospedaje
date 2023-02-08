using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using dominio = Ms.Pago.Dominio.Entidades;
using Release.MongoDB.Repository;
using System.Threading.Tasks;

namespace Ms.Pago.Aplicacion.Services
{
    public class PagoService : IPagoService
    {
        private readonly ICollectionContext<dominio.Pagos> _pagos;
        private readonly IBaseRepository<dominio.Pagos> _pagosR;

        public PagoService(ICollectionContext<dominio.Pagos> pagos, IBaseRepository<dominio.Pagos> pagosR)
        {
            _pagos = pagos;
            _pagosR = pagosR;
        }

        public List<dominio.Pagos> ListarPagos()
        {
            Expression<Func<dominio.Pagos, bool>> filter = s => s.esEliminado == false;
            var items = (_pagos.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registrar(dominio.Pagos pagos)
        {
            pagos.esEliminado = false;
            pagos.fechaCreacion = DateTime.Now;
            pagos.esActivo = true;

            // _producto.Context().InsertOne(producto);                       

            var p = _pagosR.InsertOne(pagos);

            return true;
        }

        public dominio.Pagos BuscarPorId(int idComprobante)
        {
            Expression<Func<dominio.Pagos, bool>> filter = s => s.esEliminado == false && s.idComprobante == idComprobante;
            var item = (_pagos.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idComprobante)
        {
            Expression<Func<dominio.Pagos, bool>> filter = s => s.esEliminado == false && s.idComprobante == idComprobante;
            var item = (_pagos.Context().FindOneAndDelete(filter, null));

        }

        public bool Modificar(dominio.Pagos pagos)
        {
            throw new NotImplementedException();
        }

        //public bool ActualizarStock(int idPagos)
        //{
        //    var pagos = BuscarPorId(idPagos);

        //    _pagosR.UpdateOne(pagos.id, pagos);

        //    return true;
        //}
    }
}
