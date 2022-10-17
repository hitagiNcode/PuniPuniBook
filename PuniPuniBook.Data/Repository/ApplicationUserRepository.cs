using PuniPuniBook.Data.Repository.IRepository;
using PuniPuniBook.Domain;

namespace PuniPuniBook.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
