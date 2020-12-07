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
    public class Departamento_TecnicoController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();
        //Metodo GET para mostrar todos los Deptos Tecnicos.  
        public IHttpActionResult GetallDeptoTecnico()
        {
            IList<Departamento_Tecnico> dept = db.sp_ver_todosdeptotecnico().Select(x => new Departamento_Tecnico()

            {
                Codigo_Departamento_Tecnico = x.Codigo_Departamento_Tecnico,
                Nombre = x.Nombre,
                Direccion = x.Direccion


            }).ToList<Departamento_Tecnico>();
            return Ok(dept);
        }


        //Metodo GET para ver un departamento tecnico. 
        [ResponseType(typeof(Departamento_Tecnico))]
        public IHttpActionResult GetDepartamento_Tecnico(int id)
        {
            Departamento_Tecnico departamento_Tecnico = db.Departamento_Tecnico.Find(id);
            if (departamento_Tecnico == null)
            {
                return NotFound();
            }
            Departamento_Tecnico dept = db.sp_ver_deptotecnicoID(id).Select(x => new Departamento_Tecnico()
            {
                Codigo_Departamento_Tecnico = x.Codigo_Departamento_Tecnico,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).FirstOrDefault<Departamento_Tecnico>();
            return Ok(dept);

        }

        // Metodo Put para Actualizar un departamento Tecnico. 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartamento_Tecnico(int id, Departamento_Tecnico departamento_Tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool clientexist = db.Departamento_Tecnico.Count(f => f.Codigo_Departamento_Tecnico == id) > 0;

            int actualizadept = db.sp_actualizar_deptoTecnico
               (
                  id,
                  departamento_Tecnico.Nombre,
                  departamento_Tecnico.Direccion
               );

            return Ok(actualizadept);
        }

        // Metodo POST para insertar un Departamento tecnico a la BD 
        [ResponseType(typeof(Departamento_Tecnico))]
        public IHttpActionResult PostDepartamento_Tecnico(Departamento_Tecnico departamento_Tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int postd = db.sp_insert_DeptoTecnico
               (departamento_Tecnico.Nombre,
                departamento_Tecnico.Direccion

                );

            return CreatedAtRoute("DefaultApi", new { id = departamento_Tecnico.Codigo_Departamento_Tecnico }, departamento_Tecnico);
        }

        /* DELETE: api/Departamento_Tecnico/5
        [ResponseType(typeof(Departamento_Tecnico))]
        public IHttpActionResult DeleteDepartamento_Tecnico(int id)
        {
            Departamento_Tecnico departamento_Tecnico = db.Departamento_Tecnico.Find(id);
            if (departamento_Tecnico == null)
            {
                return NotFound();
            }

            int elimin = db.sp_eliminar_Depto_Tecnico(departamento_Tecnico.Codigo_Departamento_Tecnico);

            return Ok(departamento_Tecnico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Departamento_TecnicoExists(int id)
        {
            return db.Departamento_Tecnico.Count(e => e.Codigo_Departamento_Tecnico == id) > 0;
        }*/
    }
}