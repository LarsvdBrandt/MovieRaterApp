using DataHandlerInterfaces;
using Logic;
using LogicTypes;
using MovieRaterDtos;
using MovieRaterMemoryHandler.DataTypes;
using MovieRaterMemoryHandler.Tables;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler
{
    public class RatingMemoryHandler : IRatingContext
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private TableRating ratingTable;

        //Data van tabel ophalen
        public RatingMemoryHandler(MemoryTables tables)
        {
            this.ratingTable = tables.ratings;
        }

        //In de tabel data van movieDto zetten
        public int CreateRating(RatingDto ratingDto)
        {
            return ratingTable.Insert(new DataRating(ratingDto));
        }

        //door de lijst van memorytable loopen om zo alle films in een lijst te zetten.
        public List<RatingDto> GetRatings()
        {
            List<RatingDto> ratingDtos = new List<RatingDto>();
            foreach (DataRating rating in ratingTable.Ratings)
            {
                ratingDtos.Add(rating.ToDto());
            }
            return ratingDtos;
        }

        //door de lijst van memorytable loopen om zo alle films in een lijst te zetten.
        public List<RatingDto> GetRatingsMovie(int movieID)
        {
            List<RatingDto> ratingDtos = new List<RatingDto>();
            foreach (DataRating rating in ratingTable.Ratings)
            {
                if (rating.MovieID == movieID)
                {
                    ratingDtos.Add(rating.ToDto());
                }
            }
            return ratingDtos;
        }
    }
}
