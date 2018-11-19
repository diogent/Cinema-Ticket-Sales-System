using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTicketSalesSystem.Controllers
{
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
        public ActionResult SaveProducers(EditProducersViewModel editProducers)
        {
            var newProducer = _mapper.Map<EditProducersViewModel, AddProducersModel>(editProducers);
            _producerService.SaveProducer(newProducer);
            return RedirectToAction("CreateNewMovie", "EditMovie");
        }
    }
}