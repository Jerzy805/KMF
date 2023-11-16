using KMF.Entities;
using KMF.Models;
using Microsoft.EntityFrameworkCore;

namespace KMF.Interfaces
{
    public class Repository : IRepository
    {
        private readonly ApiDb db;
        public Repository(ApiDb db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Concerto>> GetAll()
        {
            var concertos = await db.Concertos.ToListAsync();
            return concertos.OrderBy(c => c.Time);
        }

        public async Task Create(Concerto concerto)
        {
            concerto.EncodeName();

            AddNewLines(concerto);

            await db.Concertos.AddAsync(concerto);
            await db.SaveChangesAsync();
        }

        public async Task<bool> IsDbEmpty()
        {
            return !await db.Concertos.AnyAsync();
        }

        public async Task Delete(int id)
        {
            var element = await db.Concertos.FirstOrDefaultAsync(c => c.Id == id);

            if (element != null)
            {
                db.Concertos.Remove(element);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Concerto> GetByEncodedName(string encodedName)
            => await db.Concertos.FirstAsync(c => c.EncodedName == encodedName);

        public async Task Commit()
        {
            await db.SaveChangesAsync();
        }

        public async Task Delete(ConcertoDto dto)
        {
            var concerto = await db.Concertos.FirstOrDefaultAsync(c => c.EncodedName == dto.EncodedName);

            if (concerto != null)
            {
                db.Concertos.Remove(concerto);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateRange(IEnumerable<Concerto> concertos)
        {
            foreach (var concerto in concertos)
            {
                AddNewLines(concerto);
            }

            await db.Concertos.AddRangeAsync(concertos);
            await db.SaveChangesAsync();
        }

        public void AddNewLines(Concerto concerto)
        {
            concerto.ConcertProgram = concerto.ConcertProgram.Replace("nl", Environment.NewLine);
            concerto.Info = concerto.Info.Replace("nl", Environment.NewLine);
            concerto.Place = concerto.Place.Replace("nl", Environment.NewLine);
        }
    }
}
