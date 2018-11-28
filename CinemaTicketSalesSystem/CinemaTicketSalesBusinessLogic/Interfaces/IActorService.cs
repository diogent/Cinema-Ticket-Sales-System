using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IActorService
    {
        /// <summary>
        /// Saves new Actor in database
        /// </summary>
        /// <param name="addActorsModel">Model from view</param>
        void SaveActor(AddActorsModel addActorsModel);

        /// <summary>
        /// Gets all actors for mapping into ActorsViewModel. Need for selecting actors with chosen.
        /// </summary>
        /// <returns>ActorsModel collection</returns>
        IEnumerable<ActorsModel> GetActorsModel();
    }
}
