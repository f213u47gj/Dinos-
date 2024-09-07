using DinoGame.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinoGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetScores()
        {
            var scores = await _scoreRepository.GetScoreAsync();
            return Ok(scores);
        }

        [HttpPost]
        public async Task<IActionResult> PostScore([FromBody] Score score)
        {
            await _scoreRepository.AddScoreAsync(score);
            return Ok();
        }
    }
}
