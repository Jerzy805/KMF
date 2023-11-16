using KMF.Models;
using KMF.Interfaces;
using MediatR;
using AutoMapper;

namespace KMF.ConcertoCQRS.Queries.GetConcertos
{
    public class GetConcertosQueryHandler : IRequestHandler<GetConcertosQuery, IEnumerable<ConcertoDto>>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public GetConcertosQueryHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ConcertoDto>> Handle(GetConcertosQuery request, CancellationToken cancellationToken)
        {
            var concertos = await repository.GetAll();
            return mapper.Map<IEnumerable<ConcertoDto>>(concertos);
        }
    }
}
