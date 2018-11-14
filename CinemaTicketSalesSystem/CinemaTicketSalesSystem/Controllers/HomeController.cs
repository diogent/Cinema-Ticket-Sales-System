using System.Web.Mvc;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Queries;

namespace CinemaTicketSalesSystem.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Injected interface.
        /// </summary>
        private IDbService _dbService;
        public HomeController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_dbService.GetMovieInfo());
        }        

        [HttpGet]
        public ActionResult LearnMore(int id)
        {            
            var description = _dbService.GetMovieDescription(id);
            if (description == null)
                return HttpNotFound();
            return View(description);
        }
    }
}