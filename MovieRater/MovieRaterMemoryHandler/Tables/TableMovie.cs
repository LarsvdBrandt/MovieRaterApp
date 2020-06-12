using MovieRaterMemoryHandler.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler.Tables
{
    public class TableMovie
    {
        //Lijst met movies van de unit test data
        public List<DataMovie> Movies { get; set; } = new List<DataMovie>();

        //Auto increment voor unit test data
        public int Insert(DataMovie movie)
        {
            int id = GetId();

            movie.MovieID = id;
            Movies.Add(movie);

            return id;
        }

        //Auto increment voor unit test data
        private int GetId()
        {
            int id = 0;

            foreach (DataMovie movie in Movies)
            {
                if (movie.MovieID > id)
                {
                    id = movie.MovieID;
                }
            }

            id++;
            return id;
        }
    }
}
