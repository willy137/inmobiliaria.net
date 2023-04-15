namespace mvc.Models
{
	public interface IRepositorioInmueble : IRepositorio<Inmueble>
	{
        Inmueble Obtener(int id);
	}
}