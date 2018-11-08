using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;

namespace CinemaTicketSalesSystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = db.Movies;
            ViewBag.Movies = movies;
            return View();
        }        

        [HttpGet]
        public ActionResult LearnMore(int id)
        {
            ViewBag.movieId = id;
            var description = db.Movies.Find(id);
            if (description == null)
                return HttpNotFound();
            return View(description);
        }
    }
}