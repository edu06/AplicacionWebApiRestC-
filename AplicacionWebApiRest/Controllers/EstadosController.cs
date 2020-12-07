using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AplicacionWebApiRest.Models;

namespace AplicacionWebApiRest.Controllers
{
    public class EstadosController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        //Metodo GET para mostrar todos los Estados  
        public IHttpActionResult GetallEstados()
        {
            IList<Estados> est = db.sp_ver_todosestados().Select(x => new Estados()

            {
                    Codigo_Estado=x.Codigo_Estado,
                    Descripcion_Estado=x.Descripcion_Estado


            }).ToList<Estados>();
            return Ok(est);
        }


        // Metodo GET para ver estados por ID 
        [ResponseType(typeof(Estados))]
        public IHttpActionResult GetEstados(int id)
        {
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            Estados esta = db.sp_ver_estados(id).Select(x => new Estados()
            {

                Codigo_Estado = x.Codigo_Estado,
                Descripcion_Estado = x.Descripcion_Estado

            }).FirstOrDefault<Estados>();
            return Ok(esta);
        }

        // Metodo PUT para actualizar Estados. 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstados(int id, Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool Estexist = db.Estados.Count(f => f.Codigo_Estado == id) > 0;

            int actualizadept = db.sp_actualizar_Estado
               (
                  id,
                  estados.Descripcion_Estado
               );

            return Ok();
        }

        // Metodo POST para Insertar datos a la BD  en tabla Estados. 
        [ResponseType(typeof(Estados))]
        public IHttpActionResult PostEstados(Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int estd = db.sp_insert_estados
              (estados.Descripcion_Estado
                );


            return CreatedAtRoute("DefaultApi", new { id = estados.Codigo_Estado }, estados);
        }

        /* Metodo DELETE Para borrar un Estado de la BD. 
        [ResponseType(typeof(Estados))]
        public IHttpActionResult DeleteEstados(int id)
        {
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            int elimin = db.(estados.Codigo_Estado);

            return Ok(estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosExists(int id)
        {
            return db.Estados.Count(e => e.Codigo_Estado == id) > 0;
        }*/
    }
}