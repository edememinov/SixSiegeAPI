using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;

namespace RSixSiegeHUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundOutcomesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoundOutcomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RoundOutcomes
        [HttpGet]
        public IEnumerable<RoundOutcome> GetRoundOutcomes()
        {
            return _context.RoundOutcomes;
        }

        // GET: api/RoundOutcomes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoundOutcome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roundOutcome = await _context.RoundOutcomes.FindAsync(id);

            if (roundOutcome == null)
            {
                return NotFound();
            }

            return Ok(roundOutcome);
        }

        // PUT: api/RoundOutcomes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoundOutcome([FromRoute] int id, [FromBody] RoundOutcome roundOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundOutcome.RoundOutcomeId)
            {
                return BadRequest();
            }

            _context.Entry(roundOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundOutcomeExists(id))
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

        // POST: api/RoundOutcomes
        [HttpPost]
        public async Task<IActionResult> PostRoundOutcome([FromBody] RoundOutcome roundOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoundOutcomes.Add(roundOutcome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoundOutcome", new { id = roundOutcome.RoundOutcomeId }, roundOutcome);
        }

        // DELETE: api/RoundOutcomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoundOutcome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roundOutcome = await _context.RoundOutcomes.FindAsync(id);
            if (roundOutcome == null)
            {
                return NotFound();
            }

            _context.RoundOutcomes.Remove(roundOutcome);
            await _context.SaveChangesAsync();

            return Ok(roundOutcome);
        }

        private bool RoundOutcomeExists(int id)
        {
            return _context.RoundOutcomes.Any(e => e.RoundOutcomeId == id);
        }
    }
}