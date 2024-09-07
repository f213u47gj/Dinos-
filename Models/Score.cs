using System.ComponentModel.DataAnnotations;

namespace DinoGame.Repositories
{
    public class Score
    {
        public Guid ScoreId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Lastattempt { get; set; }

        public int HighScore { get; set; } 

        public Score()
        {
            Lastattempt = DateTime.UtcNow;
        }
    }
}