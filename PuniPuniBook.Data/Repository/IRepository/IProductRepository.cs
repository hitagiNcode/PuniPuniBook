using PuniPuniBook.Domain;

namespace PuniPuniBook.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
