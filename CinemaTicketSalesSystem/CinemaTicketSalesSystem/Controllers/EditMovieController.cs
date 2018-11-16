using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.IO;

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
        public ActionResult CreateNewMovie(CreateMovieViewModel movieModel, HttpPostedFileBase picture)
        {   
            if (!ModelState.IsValid)
                return View(movieModel);
            string path = _getPicturePath(picture);
            var newMovie = _mapper.Map<CreateMovieViewModel, CreateMovieModel>(movieModel);
            _movieService.CreateMovie(newMovie, path);
            return RedirectToAction("Index", "Home");
        }

        private string _getPicturePath(HttpPostedFileBase picture)
        {
            string namePicture = Path.GetFileName(picture.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), namePicture);
            picture.SaveAs(path);
            return namePicture;
        }
    }
}