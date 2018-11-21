using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSalesBusinessLogic.CRUD
{
    public class ActorService : IActorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ActorService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Saves new Actor in database
        /// </summary>
        /// <param name="addActorsModel">Model from view</param>
        public void SaveActor(AddActorsModel addActorsModel)
        {
            var newActor = _mapper.Map<AddActorsModel, Actor>(addActorsModel);
            _db.Actors.Add(newActor);
            _db.SaveChanges();    
        }

        /// <summary>
        /// Gets all actors for mapping into ActorsViewModel. Need for selecting actors with chosen.
        /// </summary>
        /// <returns>ActorsModel collection</returns>
        public IEnumerable<ActorsModel> GetActorsModel()
        {
            var actors = _db.Actors.ToList();
            var actorsModels = actors.Select(m =>
            {
                var actorsModel = _mapper.Map<Actor, ActorsModel>(m);
                return actorsModel;
            });

            return actorsModels;
        }
    }
}
