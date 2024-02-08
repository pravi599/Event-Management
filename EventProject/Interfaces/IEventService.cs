using EventProject.Models;
using EventProject.Models.DTOs;

namespace EventProject.Interfaces
{
    public interface IEventService
    {
        bool Add(EventDTO eventDTO);
        bool Remove(int id);
        EventDTO Update(EventDTO eventDTO);
        EventDTO GetEventById(int id);
        IEnumerable<EventDTO> GetAllEvents();

    }
}
