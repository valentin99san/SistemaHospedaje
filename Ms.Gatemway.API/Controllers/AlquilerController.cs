using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ms.Gateway.Aplicacion.Pedidos.Request;
using static TDA.Ms.Gateway.Api.Routes.ApiRoutes;
using Productos = TDA.Ms.Gateway.Aplicacion.ProductosClient;
using Clientes = TDA.Ms.Gateway.Aplicacion.ClientesClient;
using MediatR;

namespace TDA.Ms.Gateway.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Productos.IClient _productosClient;
        private readonly Clientes.IClient _clientesClient;

        //public ProductoController(Productos.IClient productosClient)
        //{
        //    _productosClient = productosClient;
        //}

        public AlquilerController(Productos.IClient productosClient, Clientes.IClient clientesClient)
        {
            _productosClient = productosClient;
            _clientesClient = clientesClient;
        }



        [HttpGet(RouteProducto.GetAll)]
        public ICollection<Productos.Producto> ListarProductos()
        {
            var listaProductos = _productosClient.ApiV1ProductoAllAsync().Result;
            var listaClientes = _clientesClient.ApiV1ClienteAllAsync().Result;
            return listaProductos;
        }

        [HttpGet(RoutePedido.RegistrarPedido)]
        public void RegistrarPedido(RegistrarPedidoRequest request)
        {

            // Escoger al cliente
            var cliente = _clientesClient.ApiV1ClienteAsync(request.idCliente);

            // Seleccionar producto
            var producto = _productosClient.ApiV1ProductoAsync(request.idProducto);

            // Llamar al método crear pedido

            // Llamar al método crear detalle pedido

            // Actualizar Stock
            _productosClient.ApiV1ProductoActualizarStockAsync(request.producto);


        }
    }
}
