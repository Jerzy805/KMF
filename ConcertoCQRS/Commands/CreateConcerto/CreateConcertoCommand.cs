using KMF.Models;
using MediatR;

namespace KMF.ConcertoCQRS.Commands.CreateConcerto
{
    public class CreateConcertoCommand : ConcertoDto, IRequest
    {
    }
}
