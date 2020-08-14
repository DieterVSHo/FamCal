using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamCal_backend.Models
{
    public class Event
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        
        public User Owner { get; set; }
        #endregion
    }
}
