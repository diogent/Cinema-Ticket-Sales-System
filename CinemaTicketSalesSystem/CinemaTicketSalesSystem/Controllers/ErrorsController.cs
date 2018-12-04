using System.Web.Mvc;

namespace CinemaTicketSalesSystem.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult UnAuthorize()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}