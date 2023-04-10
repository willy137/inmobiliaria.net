namespace mvc.Models;

public class Usuario{
    public int? UsuarioId { get; set; }
    public string? Nombre{ get; set; }    
    public string? Apellido { get; set; }
    public string? Password { get; set; }
    public string? Correp { get; set; }
    public string? Rol { get; set; }

    public Usuario(){

    }

}