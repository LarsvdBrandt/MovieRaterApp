using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using System.Linq;

namespace Logic
{
    public class WatchListCollection : IWatchListCollection
    {
        private IWatchListContext db;
        private List<IWatchList> watchLists;

        public WatchListCollection()
        {
            db = Factory.GetWatchListContext();
            watchLists = new List<IWatchList>();
            List<IWatchListDto> watchListDtos = db.GetWatchList();
            foreach (IWatchListDto watchListDto in watchListDtos)
            {
                watchLists.Add(new WatchList()
                {
                    UserID = watchListDto.UserID,
                    MovieID = watchListDto.MovieID,
                    WatchListID = watchListDto.WatchListID
                });
            }
        }

        public int AddWatchList(IWatchList watchList)
        {
            IWatchListDto watchListDto = Factory.GetWatchListDto();
            watchListDto.UserID = watchListDto.UserID;
            watchListDto.MovieID = watchListDto.MovieID;
            watchListDto.WatchListID = watchListDto.WatchListID;

            int rowcount = db.AddWatchList(watchListDto);
            return rowcount;
        }

        public List<IWatchList> GetWatchList()
        {
            return watchLists;
        }
    }
}
