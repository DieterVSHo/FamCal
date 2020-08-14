using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamCal_backend.Models
{
    public class User
    {
        public int id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }

        public String password { get; set; }
        //public IEnumerable<Event> FavoriteRecipes => Favorites.Select(f => f.Recipe);


        public User(String email, String firstName, String lastName)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public User()
        {
        }
    }
}
