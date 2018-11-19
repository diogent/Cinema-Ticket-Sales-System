using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
