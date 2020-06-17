using Logic;
using LogicFactory;
using LogicTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MovieRaterUnitTest
{
    [TestClass]
    public class MovieUnitTest
    {
        private MovieCollection movieCollection;

        private Movie movie;
        Factory factory;

        //zet line 10 naar moviecollection object
        [TestInitialize]
        public void Setup()
        {
            factory = new Factory();
            movieCollection = factory.GetMovieCollection(Context.Memory);
        }

        //Test CreateMovie en Getmovies
        [TestMethod]
        public void CreateMovie()
        {
            //Setup
            Movie insertMovie = new Movie()
            {
                MovieTitle = "MySpy",
                MovieInfo = "Info",
                MovieSummary = "My Spy is een Amerikaanse actie-komedie uit 2020, geregisseerd door Peter Segal, geschreven door Jon en Erich Hoeber, met in de hoofdrollen Dave Bautista, Chloe Coleman, Kristen Schaal en Ken Jeong. De film volgt een CIA-agent die moet waken over een jong meisje nadat hij is toegewezen om haar familie te beschermen.",
                Poster = "MySpy.jpg",
                Trailer = "https://www.youtube.com/embed/vOUVVDWdXbo",
                Writers = "Jeff Wadlow (screenplay by), Eric Heisserer (screenplay by)",
                Stars = "Vin Diesel, Eiza González, Sam Heughan",
                Director = "Dave Wilson (as David S.F. Wilson)"
            };

            bool found = false;

            //Action
            movieCollection.CreateMovie(insertMovie);

            //Assert
            foreach (Movie movie in movieCollection.GetMovies())
            {
                if (movie.MovieTitle.Equals("MySpy"))
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }

        //Test GetMovie
        [TestMethod]
        public void GetMovie()
        {
            //Setup

            //Action
            movie = movieCollection.GetMovie(1);

            //Assert
            Assert.AreEqual(movie.MovieTitle, "1917");
        }

        //Test EditMovie
        [TestMethod]
        public void EditMovie()
        {
            //Setup
            bool Edited = false;
            movie = movieCollection.GetMovie(1);

            //Action
            movie.MovieID = movie.MovieID;
            movie.MovieTitle = "1918";
            movie.MovieInfo = movie.MovieInfo;
            movie.MovieSummary = movie.MovieSummary;
            movie.Poster = movie.Poster;
            movie.Stars = movie.Stars;
            movie.Trailer = movie.Trailer;
            movie.Writers = movie.Writers;
            movie.Director = movie.Director;

            movieCollection.EditMovie(movie);

            if (movie.MovieTitle == "1918")
            {
                Edited = true;
            }

            //Assert
            Assert.IsTrue(Edited);
        }

        //Test DeleteMovie
        [TestMethod]
        public void DeleteMovie()
        {
            //Setup
            Movie movie = new Movie()
            {
                MovieTitle = "MySpy",
                MovieInfo = "Info",
                MovieSummary = "My Spy is een Amerikaanse actie-komedie uit 2020, geregisseerd door Peter Segal, geschreven door Jon en Erich Hoeber, met in de hoofdrollen Dave Bautista, Chloe Coleman, Kristen Schaal en Ken Jeong. De film volgt een CIA-agent die moet waken over een jong meisje nadat hij is toegewezen om haar familie te beschermen.",
                Poster = "MySpy.jpg",
                Trailer = "https://www.youtube.com/embed/vOUVVDWdXbo",
                Writers = "Jeff Wadlow (screenplay by), Eric Heisserer (screenplay by)",
                Stars = "Vin Diesel, Eiza González, Sam Heughan",
                Director = "Dave Wilson (as David S.F. Wilson)"
            };

            //Action
            movieCollection.DeleteMovie(movie);

            //Assert
            Assert.AreEqual(movieCollection.GetMovies().Where(m => m.MovieID == movie.MovieID).ToList().Count, 0);
        }
    }
}
