﻿using CinemaTicketSalesBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IProducerService
    {
        void SaveProducer(AddProducersModel addProducersModel);
    }
}
