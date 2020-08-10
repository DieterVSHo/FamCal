﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamCal_backend.Models
{
    public interface IUserRepository
    {
        User GetBy(int id);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        void SaveChanges();
    }
}
