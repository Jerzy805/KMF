using KMF.ApplicationUser;
using KMF.Interfaces;
using MediatR;

namespace KMF.ConcertoCQRS.Commands.EditConcerto
{
    public class EditConcertoCommandHandler : IRequestHandler<EditConcertoCommand>
    {
        private readonly IRepository repository;
        private readonly IUserContext userContext;
        public EditConcertoCommandHandler(IRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }

        public async Task<Unit> Handle(EditConcertoCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            if (user != null)
            {
                if (user.Email == "osiedle5@wp.pl" || user.Email == "j.chmiel2006@gmail.com")
                {
                    var concerto = await repository.GetByEncodedName(request.EncodedName);

                    concerto.Name = request.Name;
                    concerto.Place = request.Place;
                    concerto.Time = request.Time;
                    concerto.ConcertProgram = request.ConcertProgram;
                    concerto.Info = request.Info;
                    concerto.EncodeName();

                    repository.AddNewLines(concerto);
                    await repository.Commit();
                }
            }

            return Unit.Value;
        }
    }
}
