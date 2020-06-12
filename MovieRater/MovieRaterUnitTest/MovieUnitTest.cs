using Logic;
using LogicFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRaterUnitTest
{
    [TestClass]
    public class MovieUnitTest
    {
        private MovieCollection movieCollection;

        //zet line 10 naar moviecollection object
        [TestInitialize]
        public void Setup()
        {
            movieCollection = new MovieCollection();
        }

        //Test CreateMovie
        [TestMethod]
        public void CreateMovie()
        {
            //Setup
            Movie insertMovie = new Movie()
            {
                MovieTitle = "Casper",
                MovieInfo = "Lars",
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
            foreach(Movie movie in movieCollection.GetMovies())
            {
                if (movie.MovieTitle.Equals("Casper"))
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }
    }
}
