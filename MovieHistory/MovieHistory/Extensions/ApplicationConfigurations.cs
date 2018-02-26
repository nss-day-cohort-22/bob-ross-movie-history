using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieHistory.Services;

namespace MovieHistory.Configuration
{
    public class ApplicationConfigurations: IApplicationConfigurations
    {
        public string MovieAPIKey { get; set; }

    }
}
