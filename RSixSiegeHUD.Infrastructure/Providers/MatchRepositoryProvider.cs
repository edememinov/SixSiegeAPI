using Microsoft.AspNetCore.Mvc;
using RSixSiegeHUD.Data.Concrete;
using RSixSiegeHUD.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchRepositoryProvider : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchRepositoryProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetMatches()
        {
            if (_context.Matches.Count() > 0)
            {
                var matches = _context.Matches.AsEnumerable();
                return matches;
            }

            else
            {
                return null;
            }
 
            
        }

    }
}
