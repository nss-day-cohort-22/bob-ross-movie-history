using System.ComponentModel.DataAnnotations;

namespace MovieHistory.Models
{
    public class Recommendation
    {
        [Key]
        public int RecommendationId { get; set; }
        
        [Required]
        public ApplicationUser ToUser { get; set; }

        [Required]
        public int MovieUserId { get; set; }
        public MovieUser MovieUser { get; set; }
    }
}
