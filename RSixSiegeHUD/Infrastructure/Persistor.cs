using Microsoft.AspNetCore.Mvc;
using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class Persistor : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Persistor()
        {

        }

        public Persistor(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PersistObject(Object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }
    }
}
