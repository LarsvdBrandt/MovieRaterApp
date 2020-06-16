using Logic;
using LogicFactory;
using LogicInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRaterUnitTest
{
    [TestClass]
    public class MovieUnitTest
    {
        private IMovieCollection movieCollection;

        private IMovie movie;
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
                MovieTitle = "Casper",
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
                if (movie.MovieTitle.Equals("Casper"))
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
            bool found = false;

            //Action
            movie = movieCollection.GetMovie(1);
            if (movie.MovieTitle == "1917")
            {
                found = true;
            }

            //Assert
            Assert.IsTrue(found);
        }

        //Test EditMovie
        [TestMethod]
        public void EditMovie()
        {
            //Setup
            bool Edited = false;
            movie = movieCollection.GetMovie(3);

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

            movie.EditMovie();

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
            Movie insertMovie = new Movie()
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

            bool Deleted = true;
            movieCollection.CreateMovie(insertMovie);
            movie = movieCollection.GetMovie(insertMovie.MovieID);

            //Action
            movie.DeleteMovie();

            foreach (Movie movie in movieCollection.GetMovies())
            {
                if (movie.MovieID.Equals(movie.MovieID))
                {
                    Deleted = false;
                }
            }

            //Assert
            Assert.IsTrue(Deleted);
        }
    }
}
