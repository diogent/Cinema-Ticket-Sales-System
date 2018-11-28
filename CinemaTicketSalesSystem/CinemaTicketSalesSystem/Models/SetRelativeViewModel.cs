using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Models
{
    public class SetRelativeViewModel
    {    
        
        public IEnumerable<ActorsViewModel> Actors { get; set; }
        public IEnumerable<MoviesViewModel> Movies { get; set; }
        public IEnumerable<GenresViewModel> Genres { get; set; }
        public IEnumerable<ProducersViewModel> Producers { get; set; }
        
        public int[] ActorsSelectedIds { get; set; }
        public int MovieSelectedId { get; set; }
        public int[] GenresSelectedIds { get; set; }        
        public int[] ProducersSelectedIds { get; set; }
    }
}