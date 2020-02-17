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
    public class MatchOutcomesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchOutcomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MatchOutcomes
        [HttpGet]
        public IEnumerable<MatchOutcome> GetMatchOutcomes()
        {
            return _context.MatchOutcomes;
        }

        // GET: api/MatchOutcomes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchOutcome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchOutcome = await _context.MatchOutcomes.FindAsync(id);

            if (matchOutcome == null)
            {
                return NotFound();
            }

            return Ok(matchOutcome);
        }

        // PUT: api/MatchOutcomes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchOutcome([FromRoute] int id, [FromBody] MatchOutcome matchOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matchOutcome.MatchOutcomeId)
            {
                return BadRequest();
            }

            _context.Entry(matchOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchOutcomeExists(id))
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

        // POST: api/MatchOutcomes
        [HttpPost]
        public async Task<IActionResult> PostMatchOutcome([FromBody] MatchOutcome matchOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MatchOutcomes.Add(matchOutcome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchOutcome", new { id = matchOutcome.MatchOutcomeId }, matchOutcome);
        }

        public async Task<IActionResult> PersistMatchOutcome(MatchOutcome matchOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MatchOutcomes.Add(matchOutcome);
            await _context.SaveChangesAsync();

            return Ok(matchOutcome);
        }

        // DELETE: api/MatchOutcomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchOutcome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matchOutcome = await _context.MatchOutcomes.FindAsync(id);
            if (matchOutcome == null)
            {
                return NotFound();
            }

            _context.MatchOutcomes.Remove(matchOutcome);
            await _context.SaveChangesAsync();

            return Ok(matchOutcome);
        }

        private bool MatchOutcomeExists(int id)
        {
            return _context.MatchOutcomes.Any(e => e.MatchOutcomeId == id);
        }
    }
}