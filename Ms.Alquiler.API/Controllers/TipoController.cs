using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ms.Alquiler.Aplicacion.Tipo;
using Ms.Alquiler.Aplicacion.Alquiler;
using static Ms.Alquiler.API.Routes.ApiRoutes;
using dominio = Ms.Alquiler.Dominio.Entidades;

namespace Ms.Alquiler.Api.Controllers
{
    [ApiController]
    public class TipoController : ControllerBase
    {

        private readonly ITipoService _service;

        public TipoController(ITipoService service)
        {
            _service = service;
        }

        [HttpGet(RouteTipo.GetAll)]
        public IEnumerable<dominio.Categoria> ListarCategorias()
        {

            var listaTipo = _service.ListarTodos();
            return listaTipo;
        }

        [HttpGet(RouteTipo.GetById)]
        public dominio.Categoria BuscarTipo(int id)
        {
            var objCategoria = _service.BuscarPorId(id);

            return objCategoria;
        }

        [HttpPost(RouteTipo.Create)]
        public ActionResult<dominio.Tipo> CrearTipo([FromBody] dominio.Tipo tipo)
        {
            _service.Registrar(tipo);

            return Ok();
        }

       

        [HttpDelete(RouteTipo.Delete)]
        public ActionResult<dominio.Tipo> EliminarTipo(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
