

using System.ComponentModel.DataAnnotations;
namespace mvc.Models;

public class Propietario
{
    [Display(Name ="Nº Registro")]
    public int? PropId {get;set;}
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Dni { get; set; }
    public Propietario (int id,string n,string a,string dire,string tel, string dn){
        PropId=id;
        Nombre=n;
        Apellido=a;
        Direccion=dire;
        Telefono=tel;
        Dni=dn;
    }
     public Propietario (){

    }
}
