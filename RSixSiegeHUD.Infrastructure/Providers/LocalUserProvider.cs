using RSixSiegeHUD.Data.Concrete;
using RSixSiegeHUD.Data.Entities;
using System;
using System.Linq;

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
