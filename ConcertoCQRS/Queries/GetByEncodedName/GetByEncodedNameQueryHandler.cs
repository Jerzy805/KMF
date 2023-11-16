using AutoMapper;
using KMF.Interfaces;
using KMF.Models;
using MediatR;

namespace KMF.ConcertoCQRS.Queries.GetByEncodedName
{
    public class GetByEncodedNameQueryHandler : IRequestHandler<GetByEncodedNameQuery, ConcertoDto>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public GetByEncodedNameQueryHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ConcertoDto> Handle(GetByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var concerto = await repository.GetByEncodedName(request.EncodedName);
            return mapper.Map<ConcertoDto>(concerto);
        }
    }
}
