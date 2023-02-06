using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Ms.Pagos.Infraestructura.DBRepository;
using dominio = Ms.Pagos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.Pagos.Aplicacion.Entidades.Write
{
    public class PagosCommandCreate
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Pagos> _pagos;


        public PagosCommandCreate()
        {
            _pagos = _repository.db.GetCollection<dominio.Pagos>("Pagos");
        }

        public ActionResult<dominio.Pagos> CrearPagos(dominio.Pagos pagos)
        {
            pagos._id = ObjectId.GenerateNewId().ToString();
            _pagos.InsertOne(pagos);

            return CreatedAtAction("CrearPagos", pagos);
        }

        private ActionResult<dominio.Pagos> CreatedAtAction(string v, dominio.Pagos pagos)
        {
            throw new NotImplementedException();
        }
    }
}
