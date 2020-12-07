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
    public class Tecnico_SoporteController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        //Metodo GET para mostrar todos los clientes. 
        public IHttpActionResult GetallClientes()
        {
            IList<Tecnico_Soporte> tec = db.sp_ver_todoTecnicos().Select(n => new Tecnico_Soporte()

            {
                Codigo_Tecnico = n.Codigo_Tecnico,
                Primer_Nombre = n.Primer_Nombre,
                Segundo_Nombre = n.Segundo_Nombre,
                Primer_Apellido = n.Primer_Apellido,
                Segundo_Apellido=n.Segundo_Apellido,
                Direccion = n.Direccion,
                Fecha_Nacimiento = n.Fecha_Nacimiento,
                Correo_Usuario = n.Correo_Usuario,
                DPI = n.DPI,
                Codigo_Departamento_Tecnico = n.Codigo_Departamento_Tecnico,
                Codigo_Perfil = n.Codigo_Perfil,
                Pasword=n.Pasword

            }).ToList<Tecnico_Soporte>();
            return Ok(tec);

        }

                // Metodo GET Para ver los Soportes Tecnicos por ID 
                [ResponseType(typeof(Tecnico_Soporte))]
        public IHttpActionResult GetTecnico_Soporte(int id)
        {
            Tecnico_Soporte tecnico_Soporte = db.Tecnico_Soporte.Find(id);
            if (tecnico_Soporte == null)
            {
                return NotFound();
            }

            Tecnico_Soporte tecni = db.sp_ver_tecnicoID(id).Select(n => new Tecnico_Soporte()


            {
                Codigo_Tecnico = n.Codigo_Tecnico,
                Primer_Nombre = n.Primer_Nombre,
                Segundo_Nombre = n.Segundo_Nombre,
                Segundo_Apellido=n.Segundo_Apellido,
                Primer_Apellido = n.Primer_Apellido,
                Direccion = n.Direccion,
                Fecha_Nacimiento = n.Fecha_Nacimiento,
                Correo_Usuario = n.Correo_Usuario,
                DPI = n.DPI,
                Codigo_Departamento_Tecnico = n.Codigo_Departamento_Tecnico,
                Codigo_Perfil = n.Codigo_Perfil,
                

            }).FirstOrDefault<Tecnico_Soporte>();
            return Ok(tecni);
        }


        // Metodo PUT para actualizar un Tecnico Soporte. 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTecnico_Soporte(int id, Tecnico_Soporte tecnico_Soporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool updatetec = db.Tecnico_Soporte.Count(f => f.Codigo_Tecnico == id) > 0;

            int actualizatec =db.sp_actualizar_tecnico
               (
                  id,
                  tecnico_Soporte.Primer_Nombre,
                  tecnico_Soporte.Segundo_Nombre,
                  tecnico_Soporte.Primer_Apellido,
                  tecnico_Soporte.Segundo_Apellido,
                  tecnico_Soporte.Direccion,
                  tecnico_Soporte.Fecha_Nacimiento,
                  tecnico_Soporte.Correo_Usuario,
                  tecnico_Soporte.DPI,
                  tecnico_Soporte.Codigo_Departamento_Tecnico,
                  tecnico_Soporte.Codigo_Perfil,
                  tecnico_Soporte.Pasword
                  );

            return Ok(actualizatec);


        }

        // Metodo POST Para agregar un Tecnico Soporte 
        [ResponseType(typeof(Tecnico_Soporte))]
        public IHttpActionResult PostTecnico_Soporte(Tecnico_Soporte tecnico_Soporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int tecsop = db.sp_insert_tecnico
        (
         tecnico_Soporte.Primer_Nombre,
         tecnico_Soporte.Segundo_Nombre,
         tecnico_Soporte.Primer_Apellido,
         tecnico_Soporte.Segundo_Apellido,
         tecnico_Soporte.Direccion,
         tecnico_Soporte.Fecha_Nacimiento,
         tecnico_Soporte.Correo_Usuario,
         tecnico_Soporte.DPI,
         tecnico_Soporte.Codigo_Departamento_Tecnico,
         tecnico_Soporte.Codigo_Perfil,
         tecnico_Soporte.Pasword);

            return CreatedAtRoute("DefaultApi", new { id = tecnico_Soporte.Codigo_Tecnico }, tecnico_Soporte);
        }

        /*Metodo  DELETE Para borrar un tecnico 
        [ResponseType(typeof(Tecnico_Soporte))]
        public IHttpActionResult DeleteTecnico_Soporte(int id)
        {
            Tecnico_Soporte tecnico_Soporte = db.Tecnico_Soporte.Find(id);
            if (tecnico_Soporte == null)
            {
                return NotFound();
            }

            db.Tecnico_Soporte.Remove(tecnico_Soporte);
            db.SaveChanges();

            return Ok(tecnico_Soporte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tecnico_SoporteExists(int id)
        {
            return db.Tecnico_Soporte.Count(e => e.Codigo_Tecnico == id) > 0;
        }*/
    }
}