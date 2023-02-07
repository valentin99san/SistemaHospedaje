using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio = Ms.Cliente.Dominio.Entidades;

namespace Ms.Cliente.Aplicacion.Cliente
{
    public interface IClienteService
    {
        // Read
        List<dominio.Cliente> ListarClientees();
        dominio.Cliente BuscarPorId(int idCliente);

        // Write
        bool Registrar(dominio.Cliente cliente);
        bool Modificar(dominio.Cliente cliente);
        void Eliminar(int idCliente);
        bool ActualizarStock(int idCliente);
    }
}
