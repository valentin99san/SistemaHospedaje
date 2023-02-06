using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Habitacion.Dominio.Entidades;

namespace Ms.Habitacion.Aplicacion.Habitacion
{
    public interface IHabitacionService
    {
        // Read
        List<dominio.Habitacion> ListarHabitaciones();
        dominio.Habitacion BuscarPorId(int idHabitacion);

        // Write
        bool Registrar(dominio.Habitacion habitacion);
        bool Modificar(dominio.Habitacion habitacion);
        void Eliminar(int idHabitacion);
        bool ActualizarStock(int idHabitacion);
    }
}
