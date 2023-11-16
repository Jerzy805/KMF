using KMF.Entities;
using KMF.Models;

namespace KMF.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Concerto>> GetAll();
        Task Create(Concerto concerto);
        Task CreateRange(IEnumerable<Concerto> concertos);
        Task<bool> IsDbEmpty();
        Task Delete(int id);
        Task<Concerto> GetByEncodedName(string encodedName);
        Task Commit();
        Task Delete(ConcertoDto dto);
        void AddNewLines(Concerto concerto);
    }
}
