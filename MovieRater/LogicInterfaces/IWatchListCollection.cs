using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IWatchListCollection
    {
        List<IWatchList> GetWatchListMovie();
        List<IWatchList> GetWatchList();
        int CreateWatchList(IWatchList watchList);
    }
}
