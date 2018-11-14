using System;
using System.Collections.Generic;
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

            var movie2 = new Movie
            {
                Name = "The Girl In The Spider's Web",
                AgeRating = "16+",
                Description = "Lisbeth Salander, the cult figure and title character of the acclaimed Millennium " +
                "book series created by Stieg Larsson, will return to the screen in The Girl in the Spider's Web, a " +
                "first-time adaptation of the recent global bestseller.",
                DateOfPremiere = DateTime.ParseExact("09.11.2018", "dd.MM.yyyy", null),
                Actors = new List<Actor>(),
                Pictures = new List<Picture>(),
                Producers = new List<Producer>(),
                Genres = new List<Genre>()

            };

            var actor21 = new Actor { FirstName = "Claire", LastName = "Foy", DateOfBirth = DateTime.ParseExact("16.04.1986", "dd.MM.yyyy", null) };
            var actor22 = new Actor { FirstName = "Sverrir", LastName = "Gudnason", DateOfBirth = DateTime.ParseExact("12.09.1978", "dd.MM.yyyy", null) };
            var actor23 = new Actor { FirstName = "Lakeith",  LastName = "Stanfield", DateOfBirth = DateTime.ParseExact("12.08.1991", "dd.MM.yyyy", null) };
            var actor24 = new Actor { FirstName = "Sylvia", LastName = "Hoeks", DateOfBirth = DateTime.ParseExact("01.06.1983", "dd.MM.yyyy", null) };
            var actor25 = new Actor { FirstName = "Cameron", LastName = "Britton", DateOfBirth = DateTime.ParseExact("06.06.1986", "dd.MM.yyyy", null) };

            var genre21 = new Genre { Name = "Crime" };
            var genre22 = new Genre { Name = "Drama" };
            var genre23 = new Genre { Name = "Thriller" };

            var producer21 = new Producer { FirstName = "Fede", LastName = "Alvares", DateOfBirth = DateTime.ParseExact("09.02.1978", "dd.MM.yyyy", null) };
            

            var pictures21 = new Picture { Url = "/Images/TheGirlInTheSpidersWeb.jpg" };

            movie2.Pictures.Add(pictures21);

            movie2.Actors.Add(actor21);
            movie2.Actors.Add(actor22);
            movie2.Actors.Add(actor23);
            movie2.Actors.Add(actor24);
            movie2.Actors.Add(actor25);

            movie2.Producers.Add(producer21);
            

            movie2.Genres.Add(genre21);
            movie2.Genres.Add(genre22);
            movie2.Genres.Add(genre23);

            context.Movies.Add(movie1);
            context.Movies.Add(movie2);            
            base.Seed(context);
        }
    }
}
