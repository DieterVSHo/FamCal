using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamCal_backend.Models
{
    public class Event
    {
        #region Properties
        public int Id { get; set; }

        
        //[Required]
        public string title { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
        
        public string owner { get; set; }
        #endregion
    }
}
