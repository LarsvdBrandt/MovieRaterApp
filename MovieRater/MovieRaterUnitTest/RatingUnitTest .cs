using Logic;
using LogicFactory;
using LogicTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MovieRaterUnitTest
{
    [TestClass]
    public class RatingUnitTest
    {
        private RatingCollection ratingCollection;

        private Rating rating;
        Factory factory;

        //zet line 10 naar moviecollection object
        [TestInitialize]
        public void Setup()
        {
            factory = new Factory();
            ratingCollection = factory.GetRatingCollection(Context.Memory);
        }

        //Test CreateMovie en Getmovies
        [TestMethod]
        public void CreateRating()
        {
            //Setup
            Rating insertRating = new Rating()
            {
                MovieID = 1,
                RatingTitle = "Super gaaf",
                RatingStars = 4,
                RatingComment = "Heel gaaf! Echt een aanrader."
            };

            bool found = false;

            //Action
            ratingCollection.CreateRating(insertRating);

            //Assert
            foreach (Rating rating in ratingCollection.GetRatings())
            {
                if (rating.RatingTitle.Equals("Super gaaf"))
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
            rating = ratingCollection.GetRating(1);

            //Assert
            Assert.AreEqual(rating.RatingTitle, "Super mooi");
        }
    }
}
