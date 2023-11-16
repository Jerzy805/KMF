using KMF.ApplicationUser;
using KMF.ConcertoCQRS.Commands.CreateConcerto;
using KMF.ConcertoCQRS.Commands.EditConcerto;
using KMF.ConcertoCQRS.Queries.GetByEncodedName;
using KMF.ConcertoCQRS.Queries.GetConcertos;
using KMF.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KMF.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        private readonly IMediator mediator;
        private readonly IUserContext userContext;

        public HomeController(IMediator mediator, IRepository repository, IUserContext userContext)
        {
            this.mediator = mediator;
            this.repository = repository;
            this.userContext = userContext;
        }

        public async Task<IActionResult> Concertos()
        {
            var concertos = await mediator.Send(new GetConcertosQuery());
            return View(concertos);
        }

        public IActionResult Create()
        {
            if (!userContext.IsAdmin())
            {
                return RedirectToAction(nameof(NoAccess));
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertoCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Concertos");
        }

        [Route("Home/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await mediator.Send(new GetByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("Home/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await mediator.Send(new GetByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess");
            }

            return View(dto);
        }

        [HttpPost]
        [Route("Home/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditConcertoCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Concertos");
        }

        [Route("Home/{encodedName}/Delete")]
        public async Task<IActionResult> Delete(string encodedName)
        {
            var result = await mediator.Send(new GetByEncodedNameQuery(encodedName));
            await repository.Delete(result);
            return RedirectToAction("Concertos");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AboutConductor()
        {
            return View();
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Repertuar()
        {
            return View();
        }
    }
}