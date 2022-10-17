using PuniPuniBook.Domain;

namespace PuniPuniBook.Data.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
