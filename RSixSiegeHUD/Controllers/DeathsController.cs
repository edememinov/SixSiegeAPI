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
    public class DeathsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeathsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Deaths
        [HttpGet]
        public IEnumerable<Death> GetDeaths()
        {
            return _context.Deaths;
        }

        // GET: api/Deaths/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeath([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var death = await _context.Deaths.FindAsync(id);

            if (death == null)
            {
                return NotFound();
            }

            return Ok(death);
        }

        // PUT: api/Deaths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeath([FromRoute] int id, [FromBody] Death death)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != death.DeathId)
            {
                return BadRequest();
            }

            _context.Entry(death).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeathExists(id))
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

        // POST: api/Deaths
        [HttpPost]
        public async Task<IActionResult> PostDeath([FromBody] Death death)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Deaths.Add(death);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeath", new {id = death.DeathId}, death);
        }

        // DELETE: api/Deaths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeath([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var death = await _context.Deaths.FindAsync(id);
            if (death == null)
            {
                return NotFound();
            }

            _context.Deaths.Remove(death);
            await _context.SaveChangesAsync();

            return Ok(death);
        }

        private bool DeathExists(int id)
        {
            return _context.Deaths.Any(e => e.DeathId == id);
        }
    }
}