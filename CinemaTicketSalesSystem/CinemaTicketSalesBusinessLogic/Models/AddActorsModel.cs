﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class AddActorsModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }        
        public DateTime DateOfBirth { get; set; }
    }
}
