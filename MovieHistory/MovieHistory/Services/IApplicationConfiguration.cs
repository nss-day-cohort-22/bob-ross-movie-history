using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHistory.Services
{
    public interface IApplicationConfiguration
    {
        string MovieAPIKey { get; set; }
    }
}
