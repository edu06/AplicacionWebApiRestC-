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
    public class Vista_por_DeptoTecnicoController : ApiController
    {
        private DBProyectoSkyNetEntities2 db = new DBProyectoSkyNetEntities2();


        // Metodo GET Vista deptoTecnico
        [ResponseType(typeof(Vista_por_Solicitante))]
        public IHttpActionResult GetVista_por_DeptoTecnico(string dept, string usu)
        {

            var vistapordept = db.sp_ver_por_DeptoTecnico(dept, usu).Select(n => new Vista_por_DeptoTecnico()
        {
                   Departamento_Tecnico=n.Departamento_Tecnico,
                   Usuario_Tecnico=n.Usuario_Tecnico,
                   Codigo_Incidencia=n.Codigo_Incidencia,
                   Titulo_Incidencia=n.Titulo_Incidencia,
                   Descripcion=n.Descripcion,
                   Nombre_Cliente=n.Nombre_Cliente,
                   Apellido_Cliente=n.Apellido_Cliente,
                   Nombre_Receptor=n.Nombre_Receptor
         

        }).FirstOrDefault<Vista_por_DeptoTecnico>();
            return Ok(vistapordept);
    }
}
}