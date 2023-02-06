using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDA.Ms.Producto.Aplicacion.Categoria;
using TDA.Ms.Producto.Aplicacion.Producto;
using static TDA.Ms.Producto.API.Routes.ApiRoutes;
using dominio = TDA.Ms.Producto.Dominio.Entidades;

namespace TDA.Ms.Producto.Api.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet(RouteCategoria.GetAll)]
        public IEnumerable<dominio.Categoria> ListarCategorias()
        {

            var listaCategoria = _service.ListarTodos();
            return listaCategoria;
        }

        [HttpGet(RouteCategoria.GetById)]
        public dominio.Categoria BuscarCategoria(int id)
        {
            var objCategoria = _service.BuscarPorId(id);

            return objCategoria;
        }

        [HttpPost(RouteCategoria.Create)]
        public ActionResult<dominio.Categoria> CrearCategoria([FromBody] dominio.Categoria categoria)
        {
            _service.Registrar(categoria);

            return Ok();
        }

        //[HttpPut(RouteCategoria.Update)]
        //public ActionResult<dominio.Categoria> ModificarCategoria(dominio.Categoria categoria)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_categorias");
        //    var collection = database.GetCollection<dominio.Categoria>("categoria");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == categoria._id, categoria);

        //    //var oldCategoria = collection.Find(x => x.IdCategoria == categoria.IdCategoria).FirstOrDefault();
        //    //oldCategoria.Nombre = categoria.Nombre;
        //    //oldCategoria.Precio = categoria.Precio;
        //    //oldCategoria.Cantidad = categoria.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdCategoria == oldCategoria.IdCategoria, oldCategoria);


        //    //Categoria categoriaModificado = listaCategoria.Single(x => x.IdCategoria == categoria.IdCategoria);
        //    //categoriaModificado.Nombre = categoria.Nombre;
        //    //categoriaModificado.Cantidad = categoria.Cantidad;
        //    //categoriaModificado.Precio= categoria.Precio;
        //    //return CreatedAtAction("ModificarCategoria", categoriaModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteCategoria.Delete)]
        public ActionResult<dominio.Categoria> EliminarCategoria(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
