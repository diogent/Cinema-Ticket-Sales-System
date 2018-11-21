using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IActorService
    {
        void SaveActor(AddActorsModel addActorsModel);
        IEnumerable<ActorsModel> GetActorsModel();
    }
}
