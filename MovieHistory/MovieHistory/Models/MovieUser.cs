using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieHistory.Models
{
    public class MovieUser
    {
        [Key]
        // Field being indexed in db context
        public int MovieUserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public string Genre { get; set; }

        public bool Favorited { get; set; }
        public bool Watched { get; set; }

        public MovieUser() {
          Favorited = false;
          Watched = false;
        }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
    }
}
