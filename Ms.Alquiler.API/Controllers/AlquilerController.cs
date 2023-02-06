using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDA.Ms.Producto.Aplicacion.Producto;
using static TDA.Ms.Producto.API.Routes.ApiRoutes;
using dominio = TDA.Ms.Producto.Dominio.Entidades;

namespace TDA.Ms.Producto.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private const object RouteAlquiler;
        private readonly IProductoService _service;

        public AlquilerController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet(RouteProducto.GetAll)]
        public IEnumerable<dominio.Producto> ListarProductos()
        {

            var listaProducto = _service.ListarProductos();
            return listaProducto;
        }

        [HttpGet(RouteProducto.GetById)]
        public dominio.Producto BuscarProducto(int id)
        {
            var objProducto = _service.BuscarPorId(id);

            return objProducto;
        }

        [HttpPost(RouteProducto.Create)]
        public ActionResult<dominio.Producto> CrearProducto([FromBody] dominio.Producto producto)
        {
            _service.Registrar(producto);

            return Ok();
        }

        

        [HttpDelete(RouteProducto.Delete)]
        public ActionResult<dominio.Producto> EliminarProducto(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }

        [HttpPost(RouteAlquiler.ActualizarCuartos)]
        public ActionResult<dominio.Producto> ActualizarCuartos([FromBody] dominio.Alquiler alquiler)
        {
            _service.ActualizarCuartos(alquiler.idAlquiler, alquiler.precio);

            return Ok();
        }
    }
}
