﻿using System.Web.Mvc;
using CinemaTicketSalesBusinessLogic.Interfaces;
using AutoMapper;
using CinemaTicketSalesSystem.ViewModels;
using System.Collections.Generic;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesSystem.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Injected interface.
        /// </summary>
        private IMovieService _dbService;
        private IMapper _mapper;

        public HomeController(IMovieService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movieModel = _dbService.GetMovies();           
            var movieViewModel = _mapper.Map<IEnumerable<MovieModel>, IEnumerable<MovieViewModel>>(movieModel);
            return View(movieViewModel);
        }        

        [HttpGet]
        public ActionResult LearnMore(int id)
        {            
            var description = _dbService.GetMovieDetails(id);
            if (description == null)
                return HttpNotFound();
            return View(description);
        }
    }
}