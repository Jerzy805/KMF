using KMF.Entities;
using KMF.Interfaces;

namespace KMF
{
    public class ConcertoSeeder
    {
        private readonly IRepository repository;
        public ConcertoSeeder(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Seed()
        {
            if (await repository.IsDbEmpty())
            {
                List<Concerto> concertos = new List<Concerto>
                {
                    new Concerto
                    {
                        Name = "Grieg",
                        EncodedName = "grieg",
                        ConcertProgram = "E. Grieg – Koncert fortepianowy (solista Marcin Koziak), A. Dvorak – 9 Symfonia e-moll Z Nowego Świata",
                        Place = "Filharmonia Krakowska",
                        Info = "Koncert nagrywany przez Akademię Filmu i Telewizji w Warszawie",
                        Time = DateTime.Parse("2023-10-20T12:00:00")
                    },
                    new Concerto
                    {
                        Name = "Jak ojciec i syn",
                        EncodedName = "jak-ojciec-i-syn",
                        ConcertProgram = "Premiera oratorium Jak Ojciec i Syn",
                        Place = "Filharmonia Krakowska",
                        Info = "Soliści: Edyta Piasecka – sopran, Jacek Ozimkowski - bas",
                        Time = DateTime.Parse("2023-11-04T18:00:00")
                    },
                    new Concerto
                    {
                        Name = "Święto Niepodległości",
                        EncodedName = "święto-niepodległości",
                        ConcertProgram = "Polskie Pieśni Patriotyczne",
                        Place = "Filharmonia Krakowska",
                        Info = "Z udziałem Chóru Filharmonii Krakowskiej",
                        Time = DateTime.Parse("2023-11-11T12:00:00")
                    },
                    new Concerto
                    {
                        Name = "Częstochowa",
                        EncodedName = "częstochowa",
                        ConcertProgram = "---",
                        Place = "Archikatedra Częstochowska",
                        Info = "Z udziałem Chóru Archikatedry Częstochowskiej",
                        Time = DateTime.Parse("2023-11-19T16:00:00")
                    },
                    new Concerto
                    {
                        Name = "Koncert Solistów",
                        EncodedName = "koncert-solistów",
                        ConcertProgram = "Zależy od solistów",
                        Place = "Szkoła, Sala koncertowa",
                        Info = "Brak",
                        Time = DateTime.Parse("2023-12-16T18:00:00")
                    },
                    new Concerto
                    {
                        Name = "Requiem Mozarta",
                        EncodedName = "requiem-mozarta",
                        ConcertProgram = "W.A. Mozart - Requiem",
                        Place = "----",
                        Info = "Brak",
                        Time = DateTime.Parse("2024-03-24T10:00:00")
                    }
                };

                await repository.CreateRange(concertos);
            }
        }
    }
}
