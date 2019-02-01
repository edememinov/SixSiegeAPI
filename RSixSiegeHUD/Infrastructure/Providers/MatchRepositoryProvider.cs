using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchRepositoryProvider
    {
        private readonly ApplicationDbContext _context;

        public MatchProvider()
        {

        }

        public MatchProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetMatches()
        {
            var matches = _context.Matches.AsEnumerable();

            return matches;
        }

    }
}
