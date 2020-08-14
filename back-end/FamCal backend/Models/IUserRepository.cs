using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamCal_backend.Models
{
    public interface IUserRepository
    {
        User GetBy(string email);
        void Add(User user);
        void SaveChanges();
    }
}
