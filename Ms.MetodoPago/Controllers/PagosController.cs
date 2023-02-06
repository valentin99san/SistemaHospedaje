using Microsoft.AspNetCore.Mvc;
using Ms.MetodoPago.API.Routes;
using System.Collections;
using System.Collections.Generic;
using dominio = Ms.Pagos.Dominio.Entidades;
using Ms.Pagos.Aplicacion.Entidades.Pagos.Read;

namespace Ms.MetodoPago.API.Controllers
{
    [ApiController]
    public class PagosController
    {
        [HttpGet(ApiRoutes.RoutePagos.GetAll)]
        public IEnumerable<dominio.Habitacion> ListarPagos()
        {
            PagosQueryGetAll objProducto = new PagosQueryGetAll();
            var listaHabitacion = objProducto.ListarHabitacion();

            return listaHabitacion;
        }


        [HttpPost(ApiRoutes.RoutePagos.Create)]
        public ActionResult<dominio.Habitacion> CrearHabitacion(dominio.Habitacion habitacion)
        {
            HabitacionCommandCreate objHabitacion = new HabitacionCommandCreate();
            return objHabitacion.CrearHabitacion(habitacion);
        }


        [HttpPut(ApiRoutes.RoutePagos.Update)]
        public ActionResult<dominio.Habitacion> ModificarProducto(dominio.Habitacion habitacion)
        {
            HabitacionCommandUpdate objHabitacion = new HabitacionCommandUpdate();
            return objHabitacion.ModificarHabitacion(habitacion);
        }


        [HttpDelete(ApiRoutes.RoutePagos.Delete)]
        public ActionResult<dominio.Habitacion> EliminarProducto(string id)
        {
            HabitacionCommandDelete objHabitacion = new HabitacionCommandDelete();
            return objHabitacion.EliminarProducto(id);
        }
    }
}
