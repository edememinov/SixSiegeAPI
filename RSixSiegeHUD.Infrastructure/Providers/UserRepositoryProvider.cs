using RSixSiegeHUD.Data.Concrete;
using RSixSiegeHUD.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RSixSiegeHUD.Infrastructure.Providers
{
    public class UserRepositoryProvider
    {
        private readonly ApplicationDbContext _context;


        public UserRepositoryProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _context.Users.AsEnumerable();

            return users;
        }
    }
}
