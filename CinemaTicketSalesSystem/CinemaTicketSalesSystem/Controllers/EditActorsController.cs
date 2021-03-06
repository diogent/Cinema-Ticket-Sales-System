﻿using AutoMapper;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesSystem.Errors_Handler;

namespace CinemaTicketSalesSystem.Controllers
{
    [CustomAuthorize(Roles = "Admin, Moderator")]
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
        public ActionResult SaveActors(CreateActorsViewModel editActors)
        {
            if (!ModelState.IsValid)
                return View(editActors);
            var newActor = _mapper.Map<CreateActorsViewModel, AddActorsModel>(editActors);
            _actorService.SaveActor(newActor);
            return RedirectToAction("CreateNewMovie", "EditMovie");
        }        
    }
}