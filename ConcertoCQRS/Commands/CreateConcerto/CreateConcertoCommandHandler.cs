using AutoMapper;
using KMF.ApplicationUser;
using KMF.Entities;
using KMF.Interfaces;
using MediatR;

namespace KMF.ConcertoCQRS.Commands.CreateConcerto
{
    public class CreateConcertoCommandHandler : IRequestHandler<CreateConcertoCommand>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;
        public CreateConcertoCommandHandler(IRepository repository, IMapper mapper, IUserContext userContext)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userContext = userContext;
        }

        public async Task<Unit> Handle(CreateConcertoCommand command, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            if (user != null && user.IsInRole("Admin") || user!.Email == "osiedle5@wp.pl" || user!.Email == "j.chmiel2006@gmail.com")
            {
                var concerto = mapper.Map<Concerto>(command);

                await repository.Create(concerto);
            }
            
            return Unit.Value;
        }
    }
}
