using System.Web.Mvc;
using CinemaTicketSalesBusinessLogic.Queries;

namespace CinemaTicketSalesSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(DbService.GetMovieInfo());
        }        

        [HttpGet]
        public ActionResult LearnMore(int id)
        {            
            var description = DbService.GetMovieDescription(id);
            if (description == null)
                return HttpNotFound();
            return View(description);
        }
    }
}