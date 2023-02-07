using Microsoft.AspNetCore.Mvc;
using static Ms.MetodoPago.API.Routes.ApiRoutes;
using System.Collections;
using System.Collections.Generic;
using dominio = Ms.Pago.Dominio.Entidades;
using Ms.Pago.Aplicacion;
using Ms.Pago.Aplicacion.Entidades.Write;
using Ms.Pago.Aplicacion.Entidades.Read;
using Ms.Pago.Aplicacion.Services;

namespace Ms.MetodoPago.API.Controllers
{
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IPagoService _service;

        public PagosController(IPagoService service)
        {
            _service = service;
        }

        [HttpGet(RoutePagos.GetAll)]
        public IEnumerable<dominio.Pagos> ListarPagos()
        {
            //PagosQueryGetAll objPagos = new PagosQueryGetAll();
            var listaPagos = _service.ListarPagos();

            return listaPagos;
        }

        [HttpGet(RoutePagos.GetById)]
        public dominio.Pagos BuscarPagos(int id)
        {
            var objPagos = _service.BuscarPorId(id);

            return objPagos;
        }

        [HttpPost(RoutePagos.Create)]
        public ActionResult<dominio.Pagos> CrearPagos([FromBody] dominio.Pagos pago)
        {
            _service.Registrar(pago);

            return Ok();
        }

        [HttpDelete(RoutePagos.Delete)]
        public ActionResult<dominio.Pagos> EliminarPagos(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }

        //[HttpPut(RoutePagos.Update)]
        //public ActionResult<dominio.Pagos> ModificarPagos(dominio.Pagos pagos)
        //{
        //    PagosCommandUpdate objPagos = new PagosCommandUpdate();
        //    return objPagos.ModificarPagos(pagos);
        //}

        //[HttpPost(RoutePagos.Actualizar)]
        //public ActionResult<dominio.Pagos> ActualizarStock([FromBody] dominio.Pagos pago)
        //{
        //    _service.ActualizarStock(producto.idProducto, producto.cantidad);

        //    return Ok();
        //}



    }
}
