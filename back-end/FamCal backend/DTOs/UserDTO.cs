using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FamCal_backend.Models;

namespace FamCal_backend.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public UserDTO() { }
        public UserDTO(User user) : this()
        {
            FirstName = user.firstName;
            LastName = user.lastName;
            Email = user.email;
            //events
        }
    }
}
