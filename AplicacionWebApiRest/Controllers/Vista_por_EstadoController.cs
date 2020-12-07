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
    public class Vista_por_EstadoController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2    ();

        // Metodo GET Vista porEstado
        [ResponseType(typeof(Vista_por_Solicitante))]
        public IHttpActionResult GetVista_por_Estado(string est, string usu)
        {


            var vistapoest = db.sp_ver_por_estado(est, usu).Select(n => new Vista_por_Estado()
            {
      
                Estado=n.Estado,
                Usuario_Tecnico=n.Usuario_Tecnico,
                Codigo_Incidencia=n.Codigo_Incidencia,
                Titulo_Incidencia=n.Titulo_Incidencia,
                Descripcion=n.Descripcion,
                Nombre_Cliente=n.Nombre_Cliente,
                Apellido_Cliente=n.Apellido_Cliente,
                Nombre_Receptor=n.Nombre_Receptor

              }).FirstOrDefault<Vista_por_Estado>();
            return Ok(vistapoest);
        }



    }
}