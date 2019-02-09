using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
