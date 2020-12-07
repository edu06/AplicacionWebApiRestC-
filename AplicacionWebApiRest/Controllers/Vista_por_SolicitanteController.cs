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
    public class Vista_por_SolicitanteController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

 

        // Metodo GET Vista por solicitante 
        [ResponseType(typeof(Vista_por_Solicitante))]
        public IHttpActionResult GetVista_por_Solicitante(string nomb, string ape,string usu)
        {
          

            var vistaporsol = db.sp_ver_por_solicitante(nomb,ape,usu).Select(n => new Vista_por_Solicitante()
            {
                Nombre_Solicitante = n.Nombre_Solicitante,
                Apellido_Solicitante = n.Apellido_Solicitante,
                Codigo_Incidencia = n.Codigo_Incidencia,
                Titulo_Incidencia = n.Titulo_Incidencia,
                Descripcion_Incidencia = n.Descripcion_Incidencia,
                Usuario_tecnico=n.Usuario_tecnico,
                Nombre_Receptor = n.Nombre_Receptor,

                            }).FirstOrDefault<Vista_por_Solicitante>();
            return Ok(vistaporsol);
        }

       
    }
}