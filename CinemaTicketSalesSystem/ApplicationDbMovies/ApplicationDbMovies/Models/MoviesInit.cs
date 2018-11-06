using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbMovies.Contexts;
using System.Data.Entity;

namespace ApplicationDbMovies.Models
{
    class MoviesInit : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var movie1 = new Movie
            {
                Name = "Smallfoot",
                AgeRating = "6+",
                Description = "A yeti named Migo is convinced that a human known only as Smallfoot is real and has to " +
                "prove to his tribe that it does exist with the help of Meechee and the S.E.S - Smallfoot Evidentiary Society.",
                DateOfPremiere = DateTime.ParseExact("06.11.2018", "dd.MM.yyyy", null),
                Actors = new List<Actor>(),
                Pictures = new List<Picture>(),
                Producers = new List<Producer>(),
                Genres = new List<Genre>()

            };

            var actor1 = new Actor { FirstName = "Channing", LastName = "Tatum", DateOfBirth = DateTime.ParseExact("26.04.1980", "dd.MM.yyyy", null) };
            var actor2 = new Actor { FirstName = "James", LastName = "Corden", DateOfBirth = DateTime.ParseExact("22.08.1978", "dd.MM.yyyy", null) };
            var actor3 = new Actor { FirstName = "Zendaya", DateOfBirth = DateTime.ParseExact("01.09.1996", "dd.MM.yyyy", null) };
            var actor4 = new Actor { FirstName = "LeBron", LastName = "James", DateOfBirth = DateTime.ParseExact("30.12.1984", "dd.MM.yyyy", null) };

            var genre1 = new Genre { Name = "Animation" };
            var genre2 = new Genre { Name = "Adventure" };
            var genre3 = new Genre { Name = "Comedy" };

            var producer1 = new Producer { FirstName = "Karey", LastName = "Kirkpatrick", DateOfBirth = DateTime.ParseExact("14.12.1964", "dd.MM.yyyy", null) };
            var producer2 = new Producer { FirstName = "Jason", LastName = "Reisig", DateOfBirth = DateTime.ParseExact("24.08.1970", "dd.MM.yyyy", null) };

            var pictures1 = new Picture { Url = "/Images/Smallfoot.jpg" };

            movie1.Pictures.Add(pictures1);

            movie1.Actors.Add(actor1);
            movie1.Actors.Add(actor2);
            movie1.Actors.Add(actor3);
            movie1.Actors.Add(actor4);

            movie1.Producers.Add(producer1);
            movie1.Producers.Add(producer2);

            movie1.Genres.Add(genre1);
            movie1.Genres.Add(genre2);
            movie1.Genres.Add(genre3);

            context.Movies.Add(movie1);
            base.Seed(context);
        }
    }
}
