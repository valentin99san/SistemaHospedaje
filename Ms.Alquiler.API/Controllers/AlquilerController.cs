using Microsoft.AspNetCore.Mvc;
using System.Collections;
using dominio = Ms.Alquiler.Dominio.Entidades;
using System.Collections.Generic;
using static Ms.Alquiler.API.Routes.ApiRoutes;
using Ms.Alquiler.Aplicacion.Alquiler;

namespace Ms.Alquiler.Api.Controllers
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

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarAlquiler()
        {

            var listaAlquiler = _service.ListarProductos();
            return listaAlquiler;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Producto BuscarAlquiler(int id)
        {
            var objAlquiler = _service.BuscarPorId(id);

            return objAlquiler;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<dominio.Producto> CrearProducto([FromBody] dominio.Alquiler producto)
        {
            _service.Registrar(alquiler);

            return Ok();
        }

        

        [HttpDelete(RouteAlquiler.Delete)]
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
