using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using System.Web.Mvc;

namespace CinemaTicketSalesSystem.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class EditProducerController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IProducerService _producerService;

        public EditProducerController(IMapper mapper, IProducerService producerService)
        {
            _mapper = mapper;
            _producerService = producerService;
        }

        [HttpGet]
        public ActionResult Producer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveProducers(CreateProducersViewModel editProducers)
        {
            var newProducer = _mapper.Map<CreateProducersViewModel, AddProducersModel>(editProducers);
            _producerService.SaveProducer(newProducer);
            return RedirectToAction("CreateNewMovie", "EditMovie");
        }
    }
}