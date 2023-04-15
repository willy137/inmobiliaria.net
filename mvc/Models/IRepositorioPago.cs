namespace mvc.Models
{
	public interface IRepositorioPago : IRepositorio<Pago>
	{
        Pago Obtener(int id);

		IList<Pago> ObtenerPagos(int id);
	}
}