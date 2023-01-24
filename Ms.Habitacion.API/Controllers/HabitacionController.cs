using Microsoft.AspNetCore.Mvc;
using Ms.Habitacion.API.Routes;
using System.Collections;
using dominio = Ms.Habitacion.Dominio.Entidades;
using System.Collections.Generic;
using Ms.Habitacion.Aplicacion.Entidades.Habitacion.Read;


namespace Ms.Habitacion.API.Controllers
{
    [ApiController]
    public class HabitacionController
    {
        [HttpGet(ApiRoutes.RouteHabitacion.GetAll)]
        public IEnumerable<dominio.Habitacion> ListarHabitaciones()
        {
            HabitacionQueryGetAll objProducto = new HabitacionQueryGetAll();
            var listaHabitacion = objProducto.ListarProductos();

            return listaHabitacion;
        }


       
    }
}
