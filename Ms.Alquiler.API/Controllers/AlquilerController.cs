using Microsoft.AspNetCore.Mvc;
using System.Collections;
using dominio = Ms.Alquiler.Dominio.Entidades;
using System.Collections.Generic;
using static Ms.Alquiler.API.Routes.ApiRoutes;
using Ms.Alquiler.Aplicacion.Alquiler;

namespace Ms.Alquiler.API.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {

        private readonly IAlquilerService _service;

        public ProductoController(IAlquilerService service)
        {
            _service = service;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarAlquiler()
        {

            var listaAlquiler = _service.ListarAlquileres();
            return listaAlquiler;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Alquiler BuscarAlquiler(int id)
        {
            var objAlquiler = _service.BuscarPorId(id);

            return objAlquiler;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<dominio.Alquiler> CrearAlquiler([FromBody] dominio.Alquiler alquiler)
        {
            _service.Registrar(alquiler);

            return Ok();
        }


        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarAlquiler(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
