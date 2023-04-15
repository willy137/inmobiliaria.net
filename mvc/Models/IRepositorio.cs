

namespace mvc.Models{

    public interface IRepositorio<C>{

        int Create(C t);

        int Delete (int id);

        int Edit(C t);

        IList<C> GetObtenerTodos();

        C Obtener(int id);
    }


}