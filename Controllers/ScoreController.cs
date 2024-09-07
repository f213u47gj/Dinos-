using Microsoft.AspNetCore.Mvc;
using DinoDino.Models;
using DinoGame.Repositories;

namespace DinoGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : Controller
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var scores = await _scoreRepository.GetScoreAsync();
            return View(scores);
        }

        [HttpPost]
        public async Task<IActionResult> PostScore([FromBody] Score score)
        {
            await _scoreRepository.AddScoreAsync(score);
            return Ok();
        }
    }
}
