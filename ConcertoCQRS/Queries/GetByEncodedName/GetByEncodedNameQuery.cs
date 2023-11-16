using KMF.Models;
using MediatR;

namespace KMF.ConcertoCQRS.Queries.GetByEncodedName
{
    public class GetByEncodedNameQuery : IRequest<ConcertoDto>
    {
        public string EncodedName { get; set; }
        public GetByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
