using Microsoft.AspNetCore.Mvc;
using System.Collections;
using dominio = Ms.Habitacion.Dominio.Entidades;
using System.Collections.Generic;
using static Ms.Habitacion.API.Routes.ApiRoutes;
using Ms.Habitacion.Aplicacion.Habitacion;

namespace Ms.Habitacion.API.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IHabitacionService _service;

        public ProductoController(IHabitacionService service)
        {
            _service = service;
        }

        [HttpGet(RouteHabitacion.GetAll)]
        public IEnumerable<dominio.Habitacion> ListarProductos()
        {

            var listaProducto = _service.ListarHabitaciones();
            return listaProducto;
        }

        [HttpGet(RouteHabitacion.GetById)]
        public dominio.Habitacion BuscarProducto(int id)
        {
            var objProducto = _service.BuscarPorId(id);

            return objProducto;
        }

        [HttpPost(RouteHabitacion.Create)]
        public ActionResult<dominio.Habitacion> CrearProducto([FromBody] dominio.Habitacion producto)
        {
            _service.Registrar(producto);

            return Ok();
        }


        [HttpDelete(RouteHabitacion.Delete)]
        public ActionResult<dominio.Habitacion> EliminarProducto(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
