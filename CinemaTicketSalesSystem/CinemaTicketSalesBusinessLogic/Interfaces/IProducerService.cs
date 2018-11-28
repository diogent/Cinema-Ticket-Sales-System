using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IProducerService
    {
        /// <summary>
        /// This method saves a new producer.
        /// </summary>
        /// <param name="addProducerModel">Model from UI</param>
        void SaveProducer(AddProducersModel addProducersModel);

        /// <summary>
        /// This method is mapping from Producer model to ProducersModel
        /// </summary>
        IEnumerable<ProducersModel> GetProducersModel();
    }
}
