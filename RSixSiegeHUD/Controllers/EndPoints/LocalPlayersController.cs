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
    public class LocalPlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocalPlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LocalPlayers
        [HttpGet]
        public IEnumerable<LocalPlayer> GetLocalPlayers()
        {
            return _context.LocalPlayers;
        }

        // GET: api/LocalPlayers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var localPlayer = await _context.LocalPlayers.FindAsync(id);

            if (localPlayer == null)
            {
                return NotFound();
            }

            return Ok(localPlayer);
        }

        // PUT: api/LocalPlayers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalPlayer([FromRoute] int id, [FromBody] LocalPlayer localPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localPlayer.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(localPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalPlayerExists(id))
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

        // POST: api/LocalPlayers
        [HttpPost]
        public async Task<IActionResult> PostLocalPlayer([FromBody] LocalPlayer localPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LocalPlayers.Add(localPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalPlayer", new { id = localPlayer.PlayerId }, localPlayer);
        }

        public async Task<IActionResult> PersistLocalPlayer(LocalPlayer localPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LocalPlayers.Add(localPlayer);
            await _context.SaveChangesAsync();

            return Ok(localPlayer);
        }

        // DELETE: api/LocalPlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var localPlayer = await _context.LocalPlayers.FindAsync(id);
            if (localPlayer == null)
            {
                return NotFound();
            }

            _context.LocalPlayers.Remove(localPlayer);
            await _context.SaveChangesAsync();

            return Ok(localPlayer);
        }

        private bool LocalPlayerExists(int id)
        {
            return _context.LocalPlayers.Any(e => e.PlayerId == id);
        }
    }
}