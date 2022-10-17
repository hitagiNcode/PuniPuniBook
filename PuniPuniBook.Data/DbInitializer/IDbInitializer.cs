namespace PuniPuniBook.Data.DbInitializer
{
    public interface IDbInitializer : IDisposable
    {
        void Initialize();
    }
}
