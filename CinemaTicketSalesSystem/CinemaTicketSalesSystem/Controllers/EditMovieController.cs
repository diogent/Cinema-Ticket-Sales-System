using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Collections.Generic;

namespace CinemaTicketSalesSystem.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class EditMovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IProducerService _producerService;

        public EditMovieController(
             IMovieService movieService,
             IMapper mapper,
             IProducerService producerService,
             IGenreService genreService,
             IActorService actorService)
        {           
            _movieService = movieService;
            _mapper = mapper;
            _actorService = actorService;
            _producerService = producerService;
            _genreService = genreService;
        }

        [HttpGet]
        public ActionResult CreateNewMovie()
        {
            var genresList = getGenresList();
            var actorsList = getActorsList();
            var producersList = getProducersList();
            var infoForSelect = new CreateMovieViewModel
            {
                Actors = actorsList,
                Genres = genresList,
                Producers = producersList                
            };
            return View(infoForSelect);
        }

        [HttpPost]
        public ActionResult CreateNewMovie(CreateMovieViewModel movieModel, HttpPostedFileBase picture)
        {   
            if (!ModelState.IsValid)
                return View(movieModel);
            string path = getPicturePath(picture);
            var newMovie = _mapper.Map<CreateMovieViewModel, CreateMovieModel>(movieModel);
            _movieService.CreateMovie(newMovie, path);
            return RedirectToAction("EditActors", "EditActors");
        }

        /// <summary>
        /// This method saves picture into project's repository and gets the name of the picture.
        /// </summary>
        /// <param name="picture"> Picture from view </param>
        /// <returns> Name of the picture </returns>
        private string getPicturePath(HttpPostedFileBase picture)
        {
            string namePicture = Path.GetFileName(picture.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), namePicture);
            picture.SaveAs(path);
            return namePicture;
        }      
        
        /// <summary>
        /// Gets the list of actors.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ActorsViewModel> getActorsList()
        {
            var actorsModel = _actorService.GetActorsModel();
            var actorsModels = _mapper.Map<IEnumerable<ActorsModel>,
                IEnumerable<ActorsViewModel>>(actorsModel);
            return actorsModels;
        }

        /// <summary>
        /// Gets the list of producers
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ProducersViewModel> getProducersList()
        {
            var producersModel = _producerService.GetProducersModel();
            var producersModels = _mapper.Map<IEnumerable<ProducersModel>,
                IEnumerable<ProducersViewModel>>(producersModel);
            return producersModels;
        }

        /// <summary>
        /// Gets the list of genres
        /// </summary>
        /// <returns></returns>
        private IEnumerable<GenresViewModel> getGenresList()
        {
            var genresModel = _genreService.GetGenresModel();
            var genresModels = _mapper.Map<IEnumerable<GenresModel>,
                IEnumerable<GenresViewModel>>(genresModel);
            return genresModels;
        }
    }
}