using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure.Providers
{
    public class LocalUserProvider
    {
        private readonly ApplicationDbContext _context;

        public LocalUserProvider()
        {

        }

        public LocalUserProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string username)
        {
            var user = _context.Users.Where(x => x.UserName.Equals(username)).FirstOrDefault();

            return user;
        }
    }
}
