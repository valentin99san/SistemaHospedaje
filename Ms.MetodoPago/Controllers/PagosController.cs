﻿using Microsoft.AspNetCore.Mvc;
using Ms.MetodoPago.API.Routes;
using System.Collections;
using System.Collections.Generic;
using dominio = Ms.Pagos.Dominio.Entidades;
using Ms.Pagos.Aplicacion.Entidades.Read;
using Ms.Pagos.Aplicacion.Entidades.Write;
using Ms.Pagos.Aplicacion.Entidades.Update;

namespace Ms.MetodoPago.API.Controllers
{
    [ApiController]
    public class PagosController
    {
        [HttpGet(ApiRoutes.RoutePagos.GetAll)]
        public IEnumerable<dominio.Pagos> ListarPagos()
        {
            PagosQueryGetAll objPagos = new PagosQueryGetAll();
            var listaPagos = objPagos.ListarPagos();

            return listaPagos;
        }


        [HttpPost(ApiRoutes.RoutePagos.Create)]
        public ActionResult<dominio.Pagos> CrearPagos(dominio.Pagos pagos)
        {
            PagosCommandCreate objPagos = new PagosCommandCreate();
            return objPagos.CrearPagos(pagos);
        }


        [HttpPut(ApiRoutes.RoutePagos.Update)]
        public ActionResult<dominio.Pagos> ModificarPagos(dominio.Pagos pagos)
        {
            PagosCommandUpdate objPagos = new PagosCommandUpdate();
            return objPagos.ModificarPagos(pagos);
        }


        [HttpDelete(ApiRoutes.RoutePagos.Delete)]
        public ActionResult<dominio.Pagos> EliminarPagos(string id)
        {
            PagosCommandDelete objPagos = new PagosCommandDelete();
            return objPagos.EliminarPagos(id);
        }
    }
}
