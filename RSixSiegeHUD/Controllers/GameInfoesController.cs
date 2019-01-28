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
    public class GameInfoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameInfoes
        [HttpGet]
        public IEnumerable<GameInfo> GetGameInfos()
        {
            return _context.GameInfos;
        }

        // GET: api/GameInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameInfo = await _context.GameInfos.FindAsync(id);

            if (gameInfo == null)
            {
                return NotFound();
            }

            return Ok(gameInfo);
        }

        // PUT: api/GameInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameInfo([FromRoute] int id, [FromBody] GameInfo gameInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameInfo.GameInfoId)
            {
                return BadRequest();
            }

            _context.Entry(gameInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameInfoExists(id))
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

        // POST: api/GameInfoes
        [HttpPost]
        public async Task<IActionResult> PostGameInfo([FromBody] GameInfo gameInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GameInfos.Add(gameInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameInfo", new { id = gameInfo.GameInfoId }, gameInfo);
        }

        // DELETE: api/GameInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameInfo = await _context.GameInfos.FindAsync(id);
            if (gameInfo == null)
            {
                return NotFound();
            }

            _context.GameInfos.Remove(gameInfo);
            await _context.SaveChangesAsync();

            return Ok(gameInfo);
        }

        private bool GameInfoExists(int id)
        {
            return _context.GameInfos.Any(e => e.GameInfoId == id);
        }
    }
}