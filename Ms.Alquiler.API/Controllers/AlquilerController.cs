using Microsoft.AspNetCore.Mvc;
using System.Collections;
using dominio = Ms.Alquiler.Dominio.Entidades;
using System.Collections.Generic;
using static Ms.Alquiler.API.Routes.ApiRoutes;
using Ms.Alquiler.Aplicacion.Alquiler;

namespace Ms.Alquiler.API.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IAlquilerService _service;

        public ProductoController(IAlquilerService service)
        {
            _service = service;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarProductos()
        {

            var listaProducto = _service.ListarHabitaciones();
            return listaProducto;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Alquiler BuscarProducto(int id)
        {
            var objProducto = _service.BuscarPorId(id);

            return objProducto;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<dominio.Alquiler> CrearProducto([FromBody] dominio.Alquiler producto)
        {
            _service.Registrar(producto);

            return Ok();
        }


        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarProducto(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
