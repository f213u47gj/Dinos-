using Microsoft.EntityFrameworkCore;
using DinoDino.Data;


namespace DinoGame.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly DataContext _context;

        public ScoreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddScoreAsync(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Score>> GetScoreAsync()
        {
            return await _context.Scores.OrderByDescending(r => r.Lastattempt).ToListAsync();
        }
    }

}
