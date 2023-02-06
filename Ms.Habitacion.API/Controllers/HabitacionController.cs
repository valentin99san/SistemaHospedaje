using Microsoft.AspNetCore.Mvc;
using Ms.Habitacion.API.Routes;
using System.Collections;
using dominio = Ms.Habitacion.Dominio.Entidades;
using System.Collections.Generic;
using Ms.Habitacion.Aplicacion.Entidades.Habitacion.Read;
using Ms.Habitacion.Aplicacion.Entidades.Habitacion.Write;


namespace Ms.Habitacion.API.Controllers
{
    [ApiController]
    public class HabitacionController
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
