using MovieRaterMemoryHandler.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler.Tables
{
    public class TableMovie
    {
        public List<DataMovie> Movies { get; set; } = new List<DataMovie>();

        public int Insert(DataMovie movie)
        {
            int id = GetId();

            movie.MovieID = id;
            Movies.Add(movie);

            return id;
        }

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
