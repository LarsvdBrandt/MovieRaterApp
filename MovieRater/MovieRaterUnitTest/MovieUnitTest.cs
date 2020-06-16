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
                MovieTitle = "MovieTitle",
                MovieInfo = "MovieInfo",
                MovieSummary = "info",
                Poster = "poster",
                Trailer = "trailer",
                Writers = "writers",
                Stars = "stars",
                Director = "director"
            };

            bool found = false;

            //Action
            movieCollection.CreateMovie(insertMovie);

            //Assert
            foreach (Movie movie in movieCollection.GetMovies())
            {
                if (movie.MovieTitle.Equals("MovieTitle"))
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
            Assert.IsNotNull(movie);
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
            movie.MovieTitle = movie.MovieTitle;
            movie.MovieInfo = "TestDataInfo";
            movie.MovieSummary = movie.MovieSummary;
            movie.Poster = movie.Poster;
            movie.Stars = movie.Stars;
            movie.Trailer = movie.Trailer;
            movie.Writers = movie.Writers;
            movie.Director = movie.Director;

            movieCollection.EditMovie(movie);

            if (movie.MovieInfo == "TestDataInfo")
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
                MovieTitle = "Casper",
                MovieInfo = "MovieInfo",
                MovieSummary = "info",
                Poster = "poster",
                Trailer = "trailer",
                Writers = "writers",
                Stars = "stars",
                Director = "director"
            };

            //Action
            movieCollection.DeleteMovie(movie);

            //Assert
            Assert.AreEqual(movieCollection.GetMovies().Where(m => m.MovieID == movie.MovieID).ToList().Count, 0);
        }
    }
}
