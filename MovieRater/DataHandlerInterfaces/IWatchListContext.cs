using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IWatchListContext
    {
        string ConnectionString { get; set; }
        int CreateWatchList(IWatchListDto watchListDto);
        List<IWatchListDto> GetWatchListMovie();
        List<IWatchListDto> GetWatchList();

    }
}
