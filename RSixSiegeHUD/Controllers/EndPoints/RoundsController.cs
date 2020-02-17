using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSixSiegeHUD.Data.Concrete;
using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rounds
        [HttpGet]
        public IEnumerable<Round> GetRounds()
        {
            return _context.Rounds;
        }

        // GET: api/Rounds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRound([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var round = await _context.Rounds.FindAsync(id);

            if (round == null)
            {
                return NotFound();
            }

            return Ok(round);
        }

        // PUT: api/Rounds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRound([FromRoute] int id, [FromBody] Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != round.RoundId)
            {
                return BadRequest();
            }

            _context.Entry(round).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rounds
        [HttpPost]
        public async Task<IActionResult> PostRound([FromBody] Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rounds.Add(round);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRound", new { id = round.RoundId }, round);
        }

        public async Task<IActionResult> PersistRound(Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rounds.Add(round);
            await _context.SaveChangesAsync();

            return Ok(round);
        }

        // DELETE: api/Rounds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRound([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var round = await _context.Rounds.FindAsync(id);
            if (round == null)
            {
                return NotFound();
            }

            _context.Rounds.Remove(round);
            await _context.SaveChangesAsync();

            return Ok(round);
        }

        private bool RoundExists(int id)
        {
            return _context.Rounds.Any(e => e.RoundId == id);
        }
    }
}