//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionWebApiRest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comentarios_Incidencias
    {
        public int Codigo_Incidencia { get; set; }
        public string Comentario { get; set; }
    
        public virtual Incidencias Incidencias { get; set; }
    }
}