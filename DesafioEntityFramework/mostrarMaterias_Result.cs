//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesafioEntityFramework
{
    using System;
    
    public partial class mostrarMaterias_Result
    {
        public int id_materia { get; set; }
        public string nmateria { get; set; }
        public string codigo_materia { get; set; }
        public Nullable<int> curso { get; set; }
        public int id_tipo_materia { get; set; }
        public int id_titulacion { get; set; }
        public Nullable<decimal> creditos_teoricos { get; set; }
        public Nullable<decimal> creditos_laboratorio { get; set; }
        public string duracion { get; set; }
        public Nullable<int> limiteAdmision { get; set; }
        public Nullable<int> gruposTeoria { get; set; }
        public Nullable<int> gruposLaboratorio { get; set; }
    }
}
