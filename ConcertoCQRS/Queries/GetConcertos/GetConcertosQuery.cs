using KMF.Models;
using MediatR;

namespace KMF.ConcertoCQRS.Queries.GetConcertos
{
    public class GetConcertosQuery : IRequest<IEnumerable<ConcertoDto>>
    {
    }
}
