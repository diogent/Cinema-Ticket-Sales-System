using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;
using System.Linq;

namespace CinemaTicketSalesSystem.Controllers
{
    public class EditMovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public EditMovieController(IMovieService movieService, IMapper mapper)
        {           
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult CreateNewMovie()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateNewMovie(CreateMovieViewModel movieModel)
        {
            if (!ModelState.IsValid)
                return View(movieModel);            
            var newMovie = _mapper.Map<CreateMovieViewModel, CreateMovieModel>(movieModel);
            _movieService.CreateMovie(newMovie);
            return RedirectToAction("Index", "Home");

        }
    }
}