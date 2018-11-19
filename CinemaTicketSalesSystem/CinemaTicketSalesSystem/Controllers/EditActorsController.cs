using AutoMapper;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesBusinessLogic.Interfaces;

namespace CinemaTicketSalesSystem.Controllers
{
    public class EditActorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IActorService _actorService;

        public EditActorsController(IMapper mapper, IActorService actorService)
        {
            _mapper = mapper;
            _actorService = actorService;
        }

        [HttpGet]
        public ActionResult Actors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveActors(EditActorsViewModel editActors)
        {
            if (!ModelState.IsValid)
                return View(editActors);
            var newActor = _mapper.Map<EditActorsViewModel, AddActorsModel>(editActors);
            _actorService.SaveActor(newActor);
            return RedirectToAction("Index", "Home");
        }
    }
}