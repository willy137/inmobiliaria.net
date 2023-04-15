
namespace mvc.Models
{
	public interface IRepositorioUsuario : IRepositorio<Usuario>
	{
		Usuario ObtenerCorreo(string email);
	}
}