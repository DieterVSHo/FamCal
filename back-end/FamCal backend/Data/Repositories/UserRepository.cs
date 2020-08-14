using FamCal_backend.Models;
using Microsoft.EntityFrameworkCore;
using FamCal_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace FamCal_backend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FamCalContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(FamCalContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.Users;
        }

        public User GetBy(string email)
        {
            return _users.SingleOrDefault(u => u.email == email);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
