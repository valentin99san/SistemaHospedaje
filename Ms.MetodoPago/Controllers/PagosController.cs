using Microsoft.AspNetCore.Mvc;

namespace Ms.MetodoPago.API.Controllers
{
    [ApiController]
    public class PagosController
    {
        [HttpGet(ApiRoutes.RouteHabitacion.GetAll)]
        public IEnumerable<dominio.Habitacion> ListarHabitaciones()
        {
            HabitacionQueryGetAll objProducto = new HabitacionQueryGetAll();
            var listaHabitacion = objProducto.ListarHabitacion();

            return listaHabitacion;
        }


        [HttpPost(ApiRoutes.RouteHabitacion.Create)]
        public ActionResult<dominio.Habitacion> CrearHabitacion(dominio.Habitacion habitacion)
        {
            HabitacionCommandCreate objHabitacion = new HabitacionCommandCreate();
            return objHabitacion.CrearHabitacion(habitacion);
        }


        [HttpPut(ApiRoutes.RouteHabitacion.Update)]
        public ActionResult<dominio.Habitacion> ModificarProducto(dominio.Habitacion habitacion)
        {
            HabitacionCommandUpdate objHabitacion = new HabitacionCommandUpdate();
            return objHabitacion.ModificarHabitacion(habitacion);
        }


        [HttpDelete(ApiRoutes.RouteHabitacion.Delete)]
        public ActionResult<dominio.Habitacion> EliminarProducto(string id)
        {
            HabitacionCommandDelete objHabitacion = new HabitacionCommandDelete();
            return objHabitacion.EliminarProducto(id);
        }
    }
}
