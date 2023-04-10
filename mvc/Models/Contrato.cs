
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models{    


public class Contrato{

    public int? ContratoId { get; set; }
    public int? InmuId{ get; set; } 
    [ForeignKey(nameof(InmuId))]   
    public int? InquiId { get; set; }
    [ForeignKey(nameof(InquiId))]
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFinal { get; set; }
    public Decimal? MontoAlquiler { get; set; }

    public Inquilino? inquilino{get;set;}

    public Inmueble? inmueble{get;set;}

    public Contrato(){
        
    }
}

}