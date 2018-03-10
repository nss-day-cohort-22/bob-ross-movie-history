using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieHistory.Models
{
  public class Movie 
  {
    [Key]
    public int MovieId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string ImgUrl { get; set; }

    [Required]
    public int ApiId { get; set; }

    public virtual ICollection<MovieUser> MovieUsers { get; set; }

  }
}
