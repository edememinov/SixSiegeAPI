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
    public class KillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Kills
        [HttpGet]
        public IEnumerable<Kill> GetKills()
        {
            return _context.Kills;
        }

        // GET: api/Kills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kill = await _context.Kills.FindAsync(id);

            if (kill == null)
            {
                return NotFound();
            }

            return Ok(kill);
        }

        // PUT: api/Kills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKill([FromRoute] int id, [FromBody] Kill kill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kill.KillId)
            {
                return BadRequest();
            }

            _context.Entry(kill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KillExists(id))
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

        // POST: api/Kills
        [HttpPost]
        public async Task<IActionResult> PostKill([FromBody] Kill kill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kills.Add(kill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKill", new { id = kill.KillId }, kill);
        }

        public async Task<IActionResult> PersistKill(Kill kill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kills.Add(kill);
            await _context.SaveChangesAsync();

            return Ok(kill);
        }

        // DELETE: api/Kills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kill = await _context.Kills.FindAsync(id);
            if (kill == null)
            {
                return NotFound();
            }

            _context.Kills.Remove(kill);
            await _context.SaveChangesAsync();

            return Ok(kill);
        }

        private bool KillExists(int id)
        {
            return _context.Kills.Any(e => e.KillId == id);
        }
    }
}