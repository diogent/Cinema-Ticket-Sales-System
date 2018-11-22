using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IProducerService
    {
        void SaveProducer(AddProducersModel addProducersModel);
        IEnumerable<ProducersModel> GetProducersModel();
    }
}
