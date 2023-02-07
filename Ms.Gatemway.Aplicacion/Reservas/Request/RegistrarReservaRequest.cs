using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ms.Gateway.Aplicacion.AlquilerClient;

namespace Ms.Gateway.Aplicacion.Pedidos.Request
{
    public class RegistrarReservaRequest
    {
        public int idCliente { get; set; }

        public int idProducto { get; set; }

        public Producto producto { get; set; }
    }
}
