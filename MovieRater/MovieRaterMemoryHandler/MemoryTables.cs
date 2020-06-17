using MovieRaterMemoryHandler.DataTypes;
using MovieRaterMemoryHandler.Tables;
using System;

namespace MovieRaterMemoryHandler
{
    public class MemoryTables
    {
        public TableMovie movies { get; set; } = new TableMovie();
        public TableRating ratings { get; set; } = new TableRating();
        public TableAccount accounts { get; set; } = new TableAccount();

        public MemoryTables()
        {
            CreateMovie();
            CreateRating();
            CreateAccount();
        }

        //Zet default film in de table
        private void CreateMovie()
        {
            movies.Insert(new DataMovie()
            {
                MovieTitle = "1917",
                MovieInfo = "MovieInfo",
                MovieSummary = "1917 is een Amerikaans-Britse oorlogsfilm uit 2019 onder regie van Sam Mendes. De hoofdrollen worden vertolkt door Dean-Charles Chapman en George MacKay.",
                Poster = "1917.jpg",
                Trailer = "https://www.youtube.com/embed/YqNYrYUiMfg",
                Writers = "Sam Mendes, Krysty Wilson-Cairns",
                Stars = "Dean-Charles Chapman, George MacKay, Daniel Mays",
                Director = "Sam Mendes"
            });
        }

        //Zet default rating in de table
        private void CreateRating()
        {
            ratings.Insert(new DataRating()
            {
                MovieID = 1,
                RatingStars = 4,
                RatingTitle = "Super mooi",
                RatingComment = "Uitstekende film, ik heb ervan genoten."
            });
        }

        //Zet default account in de table
        private void CreateAccount()
        {
            accounts.Insert(new DataAccount()
            {
                UserName = "LarsvdB",
                FirstName = "Lars",
                LastName = "van den Brandt",
                Email = "Lars.vandenBrandt@me.com",
                PhoneNumber = 0636484221,
                Password = "W8woordT3st"
            });
        }
    }
}
