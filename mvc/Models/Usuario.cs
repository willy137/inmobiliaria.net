namespace mvc.Models;

public class Usuario{

    	public enum enRoles
	{
		Administrador = 1,
		Empleado = 2,
	}


    public int? UsuarioId { get; set; }
    public string? Nombre{ get; set; }    
    public string? Apellido { get; set; }
    public string? Password { get; set; }
    public string? Correo { get; set; }

    public int Rol { get; set; }

    public string? Avatar{get;set;}

    public string? PasswordAnterior{get;set;}

    public IFormFile? ImgAvatar{get;set;}
    public string RolNombre => Rol > 0 ? ((enRoles)Rol).ToString() : "";

    public Usuario(){

    }
}