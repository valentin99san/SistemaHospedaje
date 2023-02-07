using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Aplicacion.Alquiler
{
    public interface IAlquilerService
    {
        // Read
        List<dominio.Alquiler> ListarAlquiler();
        dominio.Alquiler BuscarPorId(int idAlquiler);

        // Write
        bool Registrar(dominio.Alquiler alquiler);
        bool Modificar(dominio.Alquiler alquiler);
        void Eliminar(int idAlquiler);
        bool ActualizarStock(int idAlquiler);
    }
}
