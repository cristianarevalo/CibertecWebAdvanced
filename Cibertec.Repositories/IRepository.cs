using System.Collections.Generic;

namespace Cibertec.Repositories
{
    //<T> where T: class, repositorio espera una clase
    public interface IRepository<T> where T: class
    {
        //en la interfaz no tiene visibilidad
        bool Delete(T entity);
        int Insert(T entity);
        bool Update(T entity);
        IEnumerable<T> GetAll();
    }
}
