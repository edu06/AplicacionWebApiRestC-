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
    public class Vista_por_TecnicoController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        // Metodo GET Vista por Tecnico 
        [ResponseType(typeof(Vista_por_Solicitante))]
        public IHttpActionResult GetVista_por_Tecnico(string nomb, string ape, string usu)
        {


            var vistaportec = db.sp_ver_por_tecnico(nomb, ape, usu).Select(n => new Vista_por_Tecnico()
            {
                  Nombre_Tecnico=n.Apellido_Tecnico,
                  Apellido_Tecnico=n.Apellido_Tecnico,
                  Usuario_Tecnico=n.Usuario_Tecnico,
                  Codigo_Incidencia=n.Codigo_Incidencia,
                  Titulo_Incidencia=n.Titulo_Incidencia,
                  Descripcion=n.Descripcion,
                  Nombre_Receptor=n.Nombre_Receptor

            }).FirstOrDefault<Vista_por_Tecnico>();
            return Ok(vistaportec);
        }
    }
}