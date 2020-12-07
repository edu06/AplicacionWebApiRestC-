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
    public class PerfilesController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        //Metodo GET para mostrar todos los Perfiles  
        public IHttpActionResult GetallPerfiles()
        {
            IList<Perfiles> perf = db.sp_ver_todosperfiles().Select(x => new Perfiles()

            {
                Codigo_Perfil = x.Codigo_Perfil,
                Descripcion_Perfil = x.Descripcion_Perfil


            }).ToList<Perfiles>();
            return Ok(perf);
        }

        // Metodo GET para ver Un perfil por ID 
        [ResponseType(typeof(Perfiles))]
        public IHttpActionResult GetPerfiles(int id)
        {
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return NotFound();
            }
            Perfiles perf = db.sp_ver_perfiles(id).Select(x => new Perfiles()
            {

                Codigo_Perfil = x.Codigo_Perfil,
                Descripcion_Perfil = x.Descripcion_Perfil

            }).FirstOrDefault<Perfiles>();
            return Ok(perf);
        }

        //Metodo PUT para Actualizar por ID. 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfiles(int id, Perfiles perfiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool updateperf = db.Perfiles.Count(f => f.Codigo_Perfil == id) > 0;

            int updateper = db.sp_actualizar_Perfil
               (
                  id,
                  perfiles.Descripcion_Perfil
               );

            return Ok();

        }

        // Metodo POST Para Almacenar Perfiles a la BD. 
        [ResponseType(typeof(Perfiles))]
        public IHttpActionResult PostPerfiles(Perfiles perfiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int postperf = db.sp_insert_perfil
                         (perfiles.Descripcion_Perfil
                           );

            return CreatedAtRoute("DefaultApi", new { id = perfiles.Codigo_Perfil }, perfiles);
        }

        // Metodo Delete para Borrar Registros de Perfiles en la BD
        [ResponseType(typeof(Perfiles))]
        public IHttpActionResult DeletePerfiles(int id)
        {
            Perfiles perfiles = db.Perfiles.Find(id);
            if (perfiles == null)
            {
                return NotFound();
            }

            db.Perfiles.Remove(perfiles);
            db.SaveChanges();

            return Ok(perfiles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilesExists(int id)
        {
            return db.Perfiles.Count(e => e.Codigo_Perfil == id) > 0;
        }
    }
}