using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHistory.Models
{
    public class TrackedMovie
    {
        public int MovieUserId { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Genre { get; set; }
        public bool Favorited { get; set; }
        public bool Watched { get; set; }
    }
}
