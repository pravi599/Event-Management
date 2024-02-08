using EventProject.Contexts;
using EventProject.Interfaces;
using EventProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly EventContext _context;
        public EventRepository(EventContext context) 
        {  
            _context = context;
        }
        public Event Add(Event entity)
        {
            _context.Events.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Event Delete(int id)
        {
            var eventa = _context.Events.Find(id);
            if (eventa != null)
            {
                _context.Events.Remove(eventa);
                _context.SaveChanges();
                return eventa;
            }
            return null;

        }

        public IList<Event> GetAll()
        {
            if (_context.Events.Count() == 0)
                return null;
            return _context.Events.ToList();
        }

        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(r => r.Id == id);
        }

        public Event Update(Event eventa)
        {
                _context.Events.Update(eventa);
                _context.SaveChanges();
                return eventa;
        }
    }
}
