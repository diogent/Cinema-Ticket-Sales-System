using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Queries;

namespace CinemaTicketSalesSystem.Controllers
{
    public class HomeController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(DbService.GetMovieInfo());
        }        

        [HttpGet]
        public ActionResult LearnMore(int id)
        {
            ViewBag.movieId = id;
            var description = DbService.GetMovieDescription(id);
            if (description == null)
                return HttpNotFound();
            return View(description);
        }
    }
}