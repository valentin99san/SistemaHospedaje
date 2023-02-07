using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Pago.Dominio.Entidades;

namespace Ms.Pago.Aplicacion.Services
{
    public interface IPagoService
    {// Read
        List<dominio.Pagos> ListarPagos();
        dominio.Pagos BuscarPorId(int idPagos);

        // Write
        bool Registrar(dominio.Pagos pagos);
        bool Modificar(dominio.Pagos pagos);
        void Eliminar(int idPagos);
        //bool ActualizarStock(int idPagos);
    }
}
