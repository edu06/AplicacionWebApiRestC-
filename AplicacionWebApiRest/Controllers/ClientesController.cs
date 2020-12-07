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
    public class ClientesController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        //Metodo GET para mostrar todos los clientes. 
        public IHttpActionResult GetallClientes()
        {
            IList<Cliente> client = db.sp_ver_todosclientes().Select(x => new Cliente()

            { 
                Codigo_Cliente = x.Codigo_Cliente,
                Primer_Nombre = x.Primer_Nombre,
                Segundo_Nombre = x.Segundo_Nombre,
                Primer_Apellido = x.Primer_Apellido,
                Segundo_Apellido = x.Segundo_Apellido,
                Direccion = x.Direccion,
                Correo = x.Correo


            }).ToList<Cliente>();


            return Ok(client);

    }

        // Metodo GET para Mostrar Clientes por ID 
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            Cliente empdetails = db.sp_ver_clientesID(id).Select(x => new Cliente()
            {
                Codigo_Cliente = x.Codigo_Cliente,
                Primer_Nombre = x.Primer_Nombre,
                Segundo_Nombre = x.Segundo_Nombre,
                Primer_Apellido = x.Primer_Apellido,
                Segundo_Apellido = x.Segundo_Apellido,
                Direccion = x.Direccion,
                Correo = x.Correo

            }).FirstOrDefault<Cliente>();
            return Ok(empdetails);
        }

        // Metodo PUT para actualizar un Cliente por ID 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool clientexist = db.Cliente.Count(f => f.Codigo_Cliente == id) > 0;

            int actualiza = db.sp_actualizar_cliente
               (
                  id,
                  cliente.Primer_Nombre,
                  cliente.Segundo_Nombre,
                  cliente.Primer_Apellido,
                  cliente.Segundo_Apellido,
                  cliente.Direccion,
                  cliente.Correo
                  );

            return Ok(actualiza);
        }

        // Metodo POST para Incertar un Cliente a la DB 
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int client = db.sp_insert_clienteID
                (cliente.Primer_Nombre,
                  cliente.Segundo_Nombre,
                  cliente.Primer_Apellido,
                  cliente.Segundo_Apellido,
                  cliente.Direccion,
                  cliente.Correo
                 );

            return CreatedAtRoute("DefaultApi", new { id = cliente.Codigo_Cliente }, cliente);
        }

        /* Metodo Para Borrar un Cliente 
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Cliente.Count(e => e.Codigo_Cliente == id) > 0;
        }*/
    }
}