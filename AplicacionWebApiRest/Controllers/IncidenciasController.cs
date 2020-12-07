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
    public class IncidenciasController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        //Metodo GET Mostrar todas las Incidencias.  
        public IHttpActionResult Getallincidencias()
        {
            IList<Incidencias> insid = db.sp_ver_todosincidencias().Select(x => new Incidencias()

            {
                Codigo_Incidencia = x.Codigo_Incidencia,
                Codigo_Receptor = x.Codigo_Receptor,
                Codigo_Solicitante = x.Codigo_Solicitante,
                Titulo_Incidencia = x.Titulo_Incidencia,
                Descripcion = x.Descripcion,
                Adjuntos = x.Adjuntos,
                Codigo_Tecnico_Asignado = x.Codigo_Tecnico_Asignado,
                Fecha_Creacion = x.Fecha_Creacion,
                Estado = x.Estado
            }).ToList<Incidencias>();

            return Ok(insid);

        }


        //Metodo GET  para Ver incidencias por ID 
        [ResponseType(typeof(Incidencias))]
        public IHttpActionResult GetIncidencias(int id)
        {
            Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return NotFound();
            }
            Incidencias inside = db.sp_ver_incidenciasID(id).Select(x => new Incidencias()
                {
                    Codigo_Incidencia = x.Codigo_Incidencia,
                    Codigo_Receptor = x.Codigo_Receptor,
                    Codigo_Solicitante = x.Codigo_Solicitante,
                    Titulo_Incidencia = x.Titulo_Incidencia,
                    Descripcion = x.Descripcion,
                    Adjuntos = x.Adjuntos,
                    Codigo_Tecnico_Asignado = x.Codigo_Tecnico_Asignado,
                    Fecha_Creacion = x.Fecha_Creacion,
                    Estado =x.Estado
                
            }).FirstOrDefault<Incidencias>();
            return Ok(inside);
        }

         // Metodo PUT para actualizar incidencias
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncidencias(int id, Incidencias incidencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        bool insidexist = db.Incidencias.Count(f => f.Codigo_Incidencia == id) > 0;

        int actualiza = db.sp_actualizar_incidencia
       (
                  id,
                  incidencias.Codigo_Receptor,
                  incidencias.Codigo_Solicitante,
                  incidencias.Titulo_Incidencia,
                  incidencias.Descripcion,
                  incidencias.Adjuntos,
                  incidencias.Codigo_Tecnico_Asignado,
                  incidencias.Fecha_Creacion,
                  incidencias.Estado
                   );
                return Ok(actualiza);
                    }

         //Metodo POST  para Insertar Incidencias. 
        [ResponseType(typeof(Incidencias))]
        public IHttpActionResult PostIncidencias(Incidencias incidencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int insiden = db.sp_insert_incidencia
             (
                  incidencias.Codigo_Receptor,
                  incidencias.Codigo_Solicitante,
                  incidencias.Titulo_Incidencia,
                  incidencias.Descripcion,
                  incidencias.Adjuntos,
                  incidencias.Codigo_Tecnico_Asignado,
                  incidencias.Fecha_Creacion,
                  incidencias.Estado
                                  );

            return CreatedAtRoute("DefaultApi", new { id = incidencias.Codigo_Incidencia }, incidencias);
        }

        /* DELETE Metodo para borrar Incidencias. 
        [ResponseType(typeof(Incidencias))]
        public IHttpActionResult DeleteIncidencias(int id)
        {
            Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return NotFound();
            }

            db.Incidencias.Remove(incidencias);
            db.SaveChanges();

            return Ok(incidencias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncidenciasExists(int id)
        {
            return db.Incidencias.Count(e => e.Codigo_Incidencia == id) > 0;
        }*/
    }
}