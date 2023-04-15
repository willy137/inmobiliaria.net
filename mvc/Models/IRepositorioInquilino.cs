namespace mvc.Models
{
	public interface IRepositorioInquilino : IRepositorio<Inquilino>
	{
        Inquilino Obtener(int id);
	}
}