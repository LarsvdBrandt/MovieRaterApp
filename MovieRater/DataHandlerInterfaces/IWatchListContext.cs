using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IWatchListContext
    {
        string ConnectionString { get; set; }
        int AddWatchList(IWatchListDto watchListDto);
        List<IWatchListDto> GetWatchList();

    }
}
