/*using DinoGame.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinoGame.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ApplicationDbContext _context;

        public ScoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Score>> GetAllAsync()
        {
            return await _context.Scores.ToListAsync();
        }

        public async Task AddAsync(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }
    }
}
*/