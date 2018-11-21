using AutoMapper;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesBusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult SelectActors()
        {
            var actorsModel = _actorService.GetActorsModel();
            var actorsModels = _mapper.Map<IEnumerable<ActorsModel>, 
                IEnumerable<ActorsViewModel>>(actorsModel);
            var actorsForSelect = new SetRelativeViewModel
            {
                Actors = actorsModels
            };
            return View(actorsForSelect);
        }

        [HttpPost]
        public ActionResult SelectActors(SetRelativeViewModel selectedActors)
        {            
            return View();
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