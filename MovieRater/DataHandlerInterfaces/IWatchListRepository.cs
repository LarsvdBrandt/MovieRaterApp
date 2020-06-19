using MovieRaterDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IWatchListRepository
    {
        string ConnectionString { get; set; }
        int CreateWatchList(WatchListDto watchListDto);
        List<WatchListDto> GetWatchListMovie();
        List<WatchListDto> GetWatchList();

    }
}
