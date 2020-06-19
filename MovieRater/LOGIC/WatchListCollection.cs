using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using System.Linq;
using MovieRaterDtos;
using DataHandler;
using LogicTypes;

namespace Logic
{
    public class WatchListCollection
    {
        private IWatchListRepository db;
        private List<WatchList> watchLists;

        public WatchListCollection()
        {
            db = new WatchListContext();
            watchLists = new List<WatchList>();
            List<WatchListDto> watchListDtos = db.GetWatchList();
            foreach (WatchListDto watchListDto in watchListDtos)
            {
                watchLists.Add(new WatchList()
                {
                    MovieID = watchListDto.MovieID
                });
            }
        }

        public int CreateWatchList(WatchList watchList)
        {
            WatchListDto watchListDto = new WatchListDto();
            watchListDto.MovieID = watchListDto.MovieID;

            int rowcount = db.CreateWatchList(watchListDto);
            return rowcount;
        }

        public List<WatchList> GetWatchListMovie()
        {
            return watchLists;
        }

        public List<WatchList> GetWatchList()
        {
            return watchLists;
        }
    }
}
