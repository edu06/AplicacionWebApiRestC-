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
    public class Vista_por_FechaController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();

        // Metodo GET Vista por Fecha
        [ResponseType(typeof(Vista_por_Solicitante))]
        public IHttpActionResult GetVista_por_fecha(DateTime fech, string usu)
        {


            var vistaporfech = db.sp_ver_por_fecha(fech, usu).Select(n => new Vista_por_Fecha()
            {
               Fecha_Creacion=n.Fecha_Creacion,
               Usuario_Tecnico=n.Usuario_Tecnico,
               Titulo_Incidencia=n.Descripcion,
               Nombre_Cliente=n.Nombre_Cliente,
               Apellido_Cliente=n.Apellido_Cliente

            }).FirstOrDefault<Vista_por_Fecha>();
            return Ok(vistaporfech);
        }
    }
}