using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models{    


public class Pago{

    public int? PagoId  { get; set; }
    public int? ContratoId { get; set; } 
    [ForeignKey(nameof(ContratoId))]   
    public int? NumeroPago { get; set; }
    public DateTime? FechaPago { get; set; }
    public Decimal? Importe { get; set; }

    public Contrato? contrato{get;set;}

    public Inmueble? inmueble{get;set;}
    public Inquilino? inquilino{get;set;}
    public Pago(){
        
    }
}

}