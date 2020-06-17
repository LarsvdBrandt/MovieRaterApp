using MovieRaterMemoryHandler.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler.Tables
{
    public class TableRating
    {
        //Lijst met ratings van de unit test data
        public List<DataRating> Ratings { get; set; } = new List<DataRating>();

        //Auto increment voor unit test data
        public int Insert(DataRating rating)
        {
            int id = GetId();

            rating.RatingID = id;
            Ratings.Add(rating);

            return id;
        }

        //Auto increment voor unit test data
        private int GetId()
        {
            int id = 0;

            foreach (DataRating rating in Ratings)
            {
                if (rating.RatingID > id)
                {
                    id = rating.RatingID;
                }
            }

            id++;
            return id;
        }
    }
}
