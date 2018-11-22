using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSalesBusinessLogic.CRUD
{
    public class ProducerService : IProducerService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProducerService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// This method saves a new producer.
        /// </summary>
        /// <param name="addProducerModel">Model from UI</param>
        public void SaveProducer(AddProducersModel addProducerModel)
        {
            var newProducer = _mapper.Map<AddProducersModel, Producer>(addProducerModel);
            _db.Producers.Add(newProducer);
            _db.SaveChanges();
        }

        /// <summary>
        /// This method is mapping from Producer model to ProducersModel
        /// </summary>
        public IEnumerable<ProducersModel> GetProducersModel()
        {
            var producers = _db.Producers.ToList();
            var producersModels = _mapper.Map<IEnumerable<Producer>, IEnumerable<ProducersModel>>(producers);
            return producersModels;
        }
    }
}
