using FamCal_backend.Models;
using Microsoft.EntityFrameworkCore;
using FamCal_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace FamCal_backend.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly FamCalContext _context;
        private readonly DbSet<Event> _events;

        public EventRepository(FamCalContext dbContext)
        {
            _context = dbContext;
            _events = dbContext.Events;
        }

        public IEnumerable<Event> GetAll()
        {
            //return _events.Include(r => r.Ingredients).ToList();
            return _events.ToList();

        }

        public Event GetBy(int id)
        {
            //return _events.Include(r => r.Ingredients).SingleOrDefault(r => r.Id == id);
            return _events.SingleOrDefault(r => r.Id == id);

        }

        /*        public bool TryGetEvent(int id, out Event ev)
                {
                    ev = _context.Events.Include(t => t.Ingredients).FirstOrDefault(t => t.Id == id);
                    return ev != null;
                }*/

        public void Add(Event ev)
        {
            _events.Add(ev);
        }

        public void Update(Event ev)
        {
            _context.Update(ev);
        }

        public void Delete(Event ev)
        {
            _events.Remove(ev);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetBy(string title = null, string startDate = null, string endDate = null, string owner = null)
        {
            var events = _events;
            if (!string.IsNullOrEmpty(title))
                events = (DbSet<Event>)events.Where(r => r.Title.IndexOf(title, System.StringComparison.OrdinalIgnoreCase) >= 0);

            return events.OrderBy(r => r.Title).ToList();
        }
    }
}