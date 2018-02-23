using System.ComponentModel.DataAnnotations;

namespace MovieHistory.Models
{
    public class Recommendation
    {
        [Key]
        public int RecommendationId { get; set; }
    }
}