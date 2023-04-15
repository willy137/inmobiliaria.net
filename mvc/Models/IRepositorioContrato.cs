namespace mvc.Models
{
	public interface IRepositorioContrato : IRepositorio<Contrato>
	{
        Contrato Obtener(int id);
	}
}