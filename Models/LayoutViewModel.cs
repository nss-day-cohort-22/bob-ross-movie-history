using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHistory.ViewModels
{
    public class LayoutViewModel
    {
        public IConfiguration _Configuration { get; set; }

        public LayoutViewModel(IConfiguration config)
        {
            _Configuration = config;
        }
    }
}
