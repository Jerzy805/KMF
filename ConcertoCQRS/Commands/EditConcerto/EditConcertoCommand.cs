using KMF.Models;
using MediatR;

namespace KMF.ConcertoCQRS.Commands.EditConcerto
{
    public class EditConcertoCommand : ConcertoDto, IRequest
    {
    }
}
