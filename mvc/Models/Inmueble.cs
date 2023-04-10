
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models{    
    public class Inmueble
    {

        public int? InmuId {get;set;}
        [Display(Name ="Nº Reg.Propietario")]
        public string? PropId { get; set; }
        [ForeignKey(nameof(PropId))]

        public string? Direccion { get; set; }
        
        public string? UsoComercial { get; set; }

        public string? TipoLocal { get; set; }
        
        public int? CantidadAmbientes { get; set; }
        
        public int? Latitud { get; set; }

        public int? Longitud { get; set; }

        public Decimal? Precio { get; set; }

        [Display (Name = "Propietario")]    
        public Propietario? Duenio{get;set;}

        public Inmueble (){

        }
    }
}

