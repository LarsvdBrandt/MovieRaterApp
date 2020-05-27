using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataHandlerInterfaces;

namespace DataHandler.Models
{
    public class WatchListDto : IWatchListDto
    {
        public int MovieID { get; set; }
    }
}
