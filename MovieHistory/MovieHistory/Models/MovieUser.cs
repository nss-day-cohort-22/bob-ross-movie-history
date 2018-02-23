using System.ComponentModel.DataAnnotations;

namespace MovieHistory.Models
{
    public class MovieUser
    {
        [Key]
        public int MovieUserId { get; set; }
    }
}