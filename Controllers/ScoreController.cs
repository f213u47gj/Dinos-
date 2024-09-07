using DinoGame.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinoGame.Controllers
{
    public class ScoreController : Controller
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _scoreRepository.GetScoreAsync();
            return View(results);
        }

        [HttpPost]
        public async Task<IActionResult> PostScore([FromBody] Score score)
        {
            if (score == null)
            {
                return BadRequest();
            }

            if (score.HighScore > 0)
            {
                await _scoreRepository.AddScoreAsync(score);
            }

            await _scoreRepository.AddScoreAsync(score);
            return Ok();
        }
    }
}
