using System.Collections.Generic;

namespace FamCal_backend.Models
{
    public interface IEventRepository
    {
        Event GetBy(int id);
        bool TryGetEvent(int id, out Event ev);
        IEnumerable<Event> GetAll();
        IEnumerable<Event> GetBy(string title = null);
        void Add(Event ev);
        void Delete(Event ev);
        void Update(Event ev);
        void SaveChanges();
    }
}