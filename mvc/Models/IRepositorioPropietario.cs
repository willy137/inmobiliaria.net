namespace mvc.Models
{
	public interface IRepositorioPropietario : IRepositorio<Propietario>
	{
        IList<Propietario> BuscarNom(string nom);
        Propietario Obtener(int id);
    }
}