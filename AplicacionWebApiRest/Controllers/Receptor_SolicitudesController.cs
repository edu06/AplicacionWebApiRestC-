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
    public class Receptor_SolicitudesController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        //Metodo GET para mostrar todos los Receptores de Solicitud. 
        public IHttpActionResult GetallReceptores()
        {
            IList<Receptor_Solicitudes> recep = db.sp_ver_todosreceptor().Select(x => new Receptor_Solicitudes()

            {
                Codigo_Receptor = x.Codigo_Receptor,
                Primer_Nombre = x.Primer_Nombre,
                Segundo_Nombre = x.Segundo_Nombre,
                Primer_Apellido = x.Primer_Apellido,
                Segundo_Apellido = x.Segundo_Apellido,
                Direccion = x.Direccion,
                Fecha_Nacimiento = x.Fecha_Nacimiento,
                Correo = x.Correo,
                DPI = x.DPI,
                Codigo_Perfil = x.Codigo_Perfil,
                Pasword = x.Pasword


            }).ToList<Receptor_Solicitudes>();
            return Ok(recep);

        }


        // Metodo GET Para visualizar receptores por ID 
        [ResponseType(typeof(Receptor_Solicitudes))]
        public IHttpActionResult GetReceptor_Solicitudes(int id)
        {
            Receptor_Solicitudes receptor_Solicitudes = db.Receptor_Solicitudes.Find(id);
            if (receptor_Solicitudes == null)
            {
                return NotFound();
            }
            Receptor_Solicitudes recept = db.sp_ver_receptorID(id).Select(x => new Receptor_Solicitudes()
            {
                Codigo_Receptor = x.Codigo_Receptor,
                Primer_Nombre = x.Primer_Nombre,
                Segundo_Nombre = x.Segundo_Nombre,
                Primer_Apellido = x.Primer_Apellido,
                Segundo_Apellido = x.Segundo_Apellido,
                Direccion = x.Direccion,
                Fecha_Nacimiento = x.Fecha_Nacimiento,
                Correo = x.Correo,
                DPI = x.DPI,
                Codigo_Perfil = x.Codigo_Perfil,
                Pasword = x.Pasword
            }).FirstOrDefault<Receptor_Solicitudes>();
            return Ok(recept);
        }

        // Metodo PUT Para actualizar Receptor de solicitudes por ID  
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReceptor_Solicitudes(int id, Receptor_Solicitudes receptor_Solicitudes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool updaterecep = db.Receptor_Solicitudes.Count(f => f.Codigo_Receptor == id) > 0;

            int actualiza = db.sp_actualizar_receptor
               (
                  id,
                  receptor_Solicitudes.Primer_Nombre,
                  receptor_Solicitudes.Segundo_Nombre,
                  receptor_Solicitudes.Primer_Apellido,
                  receptor_Solicitudes.Segundo_Apellido,
                  receptor_Solicitudes.Direccion,
                  receptor_Solicitudes.Fecha_Nacimiento,
                  receptor_Solicitudes.Correo,
                  receptor_Solicitudes.DPI,
                  receptor_Solicitudes.Codigo_Perfil,
                  receptor_Solicitudes.Pasword
                  );

            return Ok(actualiza);
        }

        //Metodo POST Para Insertar un Receptor de Solicitudes por ID. 
        [ResponseType(typeof(Receptor_Solicitudes))]
        public IHttpActionResult PostReceptor_Solicitudes(Receptor_Solicitudes receptor_Solicitudes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int recept = db.sp_insert_receptor
          (
           receptor_Solicitudes.Primer_Nombre,
           receptor_Solicitudes.Segundo_Nombre,
           receptor_Solicitudes.Primer_Apellido,
           receptor_Solicitudes.Segundo_Apellido,
           receptor_Solicitudes.Direccion,
           receptor_Solicitudes.Fecha_Nacimiento,
           receptor_Solicitudes.Correo,
           receptor_Solicitudes.DPI,
           receptor_Solicitudes.Codigo_Perfil,
           receptor_Solicitudes.Pasword);

            return CreatedAtRoute("DefaultApi", new { id = receptor_Solicitudes.Codigo_Receptor }, receptor_Solicitudes);
        }

        /* Metodo DELETE PARA Borrar un Receptor. 
        [ResponseType(typeof(Receptor_Solicitudes))]
        public IHttpActionResult DeleteReceptor_Solicitudes(int id)
        {
            Receptor_Solicitudes receptor_Solicitudes = db.Receptor_Solicitudes.Find(id);
            if (receptor_Solicitudes == null)
            {
                return NotFound();
            }

            db.Receptor_Solicitudes.Remove(receptor_Solicitudes);
            db.SaveChanges();

            return Ok(receptor_Solicitudes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Receptor_SolicitudesExists(int id)
        {
            return db.Receptor_Solicitudes.Count(e => e.Codigo_Receptor == id) > 0;
        }*/
    }
}