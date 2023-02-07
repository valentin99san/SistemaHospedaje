using Microsoft.AspNetCore.Mvc;
using System.Collections;
using dominio = Ms.Cliente.Dominio.Entidades;
using System.Collections.Generic;
using static Ms.Cliente.API.Routes.ApiRoutes;
using Ms.Cliente.Aplicacion.Cliente;

namespace Ms.Cliente.API.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IClienteService _service;

        public ProductoController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet(RouteCliente.GetAll)]
        public IEnumerable<dominio.Cliente> ListarProductos()
        {

            var listaProducto = _service.ListarClientees();
            return listaProducto;
        }

        [HttpGet(RouteCliente.GetById)]
        public dominio.Cliente BuscarProducto(int id)
        {
            var objProducto = _service.BuscarPorId(id);

            return objProducto;
        }

        [HttpPost(RouteCliente.Create)]
        public ActionResult<dominio.Cliente> CrearProducto([FromBody] dominio.Cliente producto)
        {
            _service.Registrar(producto);

            return Ok();
        }


        [HttpDelete(RouteCliente.Delete)]
        public ActionResult<dominio.Cliente> EliminarProducto(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
