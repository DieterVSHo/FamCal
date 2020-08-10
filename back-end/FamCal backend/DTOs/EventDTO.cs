using FamCal_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamCal_backend.DTOs
{
    public class EventDTO
    {
        public string title { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public User owner { get; set; }
    }
}
