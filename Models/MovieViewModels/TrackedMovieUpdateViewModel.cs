using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHistory.Models.MovieViewModels
{
    public class TrackedMovieUpdateViewModel
    {
        public string Genre { get; set; }
        public bool Favorited { get; set; }
        public bool Waatched { get; set; }
    }
}
