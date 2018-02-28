using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHistory.Models.MovieViewModels
{
    public class TrackedMoviesViewModel
    {
        public ICollection<TrackedMovie> TrackedUserMovies { get; set; }
    }
}
