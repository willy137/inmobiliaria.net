namespace mvc.Models;

public class Propietario
{
    public int? Id_prop {get;set;}
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Dni { get; set; }
    public Propietario (int id,string n,string a,string dire,string tel, string dn){
        Id_prop=id;
        Nombre=n;
        Apellido=a;
        Direccion=dire;
        Telefono=tel;
        Dni=dn;
    }
     public Propietario (){

    }
}
