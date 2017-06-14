using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository: IRepository<product>
    {
        product SearchByProductName(string ProductName);
    }
}
