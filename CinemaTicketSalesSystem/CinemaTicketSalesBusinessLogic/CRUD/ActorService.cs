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
        
        public IEnumerable<ActorsModel> GetActorsModel()
        {
            var actors = _db.Actors.ToList();
            var actorsModels = _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorsModel>>(actors);    
            return actorsModels;
        }

        public void SaveActor(AddActorsModel addActorsModel)
        {
            var newActor = _mapper.Map<AddActorsModel, Actor>(addActorsModel);
            _db.Actors.Add(newActor);
            _db.SaveChanges();    
        }        
    }
}
