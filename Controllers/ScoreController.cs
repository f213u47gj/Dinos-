/*using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DinoGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return _context.Scores;
        }
    }

    public class Score
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}*/